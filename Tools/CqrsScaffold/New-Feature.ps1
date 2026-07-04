<#
.SYNOPSIS
    Scaffolding Tool لمشروع CraftIQ Clean Architecture.
    بيولد Skeleton بتاع CQRS Feature (Command/Query + Handler + Validator)
    من Templates خارجية بدون أي كود C# مكتوب جوه السكريبت نفسه.

.DESCRIPTION
    الأداة دي بتقرا Templates من مجلد Templates/ جنبها، بتستبدل الـ Placeholders
    (زي {{Entity}}, {{Namespace}}, {{ResponseType}}, {{ClassPrefix}})، وبتنشئ
    الملفات والفولدرات المطلوبة تلقائيًا.

    ملحوظة: الأداة دي بتعمل Skeleton فاضي بس (بدون Business Logic، بدون
    Repository، بدون UnitOfWork، بدون AutoMapper، بدون Specifications).
    كل Method بترمي NotImplementedException وانت اللي هتضيف اللوجيك بنفسك.

.PARAMETER Entity
    اسم الـ Entity بالمفرد (مثال: Product, Order, Customer)

.PARAMETER Operation
    نوع العملية: Create, Update, Delete, GetById, GetAll

.PARAMETER ApplicationPath
    مسار مجلد Application في المشروع (افتراضيًا مسار مشروع CraftIQ عندك)

.PARAMETER RootNamespace
    الـ Namespace الأساسي (افتراضيًا CraftIQ.Application)

.PARAMETER Force
    لو موجود، هيعمل Overwrite للملفات الموجودة بالفعل

.EXAMPLE
    .\New-Feature.ps1 -Entity Product -Operation Create

.EXAMPLE
    .\New-Feature.ps1 -Entity Product -Operation GetById -Force
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern('^[A-Za-z][A-Za-z0-9]*$')]
    [string]$Entity,

    [Parameter(Mandatory = $true)]
    [ValidateSet("Create", "Update", "Delete", "GetById", "GetAll")]
    [string]$Operation,

    [string]$ApplicationPath = "C:\Users\Hardware\source\repos\CraftIQ\Application",

    [string]$RootNamespace = "CraftIQ.Application",

    [switch]$Force
)

$ErrorActionPreference = "Stop"
$TemplatesRoot = Join-Path $PSScriptRoot "Templates"

# ============================================================
#  الدوال الأساسية (Functions)
# ============================================================

function Get-Template {
    <#
        بتقرا محتوى ملف Template معين من جوه مجلد Templates/{Operation}/{FileName}
    #>
    param(
        [Parameter(Mandatory = $true)][string]$OperationName,
        [Parameter(Mandatory = $true)][string]$FileName
    )

    $templatePath = Join-Path $TemplatesRoot (Join-Path $OperationName $FileName)

    if (-not (Test-Path $templatePath)) {
        throw "Template غير موجود: $templatePath"
    }

    return Get-Content -Path $templatePath -Raw
}

function Replace-Tokens {
    <#
        بتستبدل كل الـ Placeholders زي {{Entity}} بالقيم الفعلية من Tokens hashtable
    #>
    param(
        [Parameter(Mandatory = $true)][string]$Content,
        [Parameter(Mandatory = $true)][hashtable]$Tokens
    )

    foreach ($key in $Tokens.Keys) {
        $pattern = [regex]::Escape("{{$key}}")
        $replacement = $Tokens[$key] -replace '\$', '$$$$'   # عشان $ متتفسرش كـ regex group reference
        $Content = $Content -replace $pattern, $replacement
    }

    return $Content
}

function Create-Directory {
    <#
        بتنشئ الفولدر لو مش موجود، وبتطبع رسالة تأكيد
    #>
    param([Parameter(Mandatory = $true)][string]$Path)

    if (-not (Test-Path $Path)) {
        New-Item -ItemType Directory -Path $Path -Force | Out-Null
        Write-Host "  [+] تم إنشاء الفولدر: $Path" -ForegroundColor DarkGray
    }
}

function Generate-File {
    <#
        بتكتب محتوى في ملف. لو الملف موجود بالفعل ومفيش -Force، بتتخطاه وتطبع تحذير
    #>
    param(
        [Parameter(Mandatory = $true)][string]$Path,
        [Parameter(Mandatory = $true)][string]$Content
    )

    if ((Test-Path $Path) -and (-not $Force)) {
        Write-Host "  [SKIP] الملف موجود بالفعل: $Path (استخدم -Force للاستبدال)" -ForegroundColor Yellow
        return
    }

    Set-Content -Path $Path -Value $Content -Encoding UTF8
    Write-Host "  [OK]   $Path" -ForegroundColor Green
}

function Get-ClassPrefix {
    <#
        بتحسب اسم الكلاس الأساسي (Prefix) حسب نوع العملية
        Create  -> Create{Entity}
        Update  -> Update{Entity}
        Delete  -> Delete{Entity}
        GetById -> Get{Entity}ById
        GetAll  -> GetAll{Entity}
    #>
    param(
        [Parameter(Mandatory = $true)][string]$EntityName,
        [Parameter(Mandatory = $true)][string]$OperationName
    )

    switch ($OperationName) {
        "Create"  { return "Create$EntityName" }
        "Update"  { return "Update$EntityName" }
        "Delete"  { return "Delete$EntityName" }
        "GetById" { return "Get${EntityName}ById" }
        "GetAll"  { return "GetAll$EntityName" }
    }
}

function Get-ResponseType {
    <#
        بترجع نوع الـ Response المناسب حسب نوع العملية
        (القيم دي متفق عليها مسبقًا حسب متطلبات مشروع CraftIQ)
    #>
    param(
        [Parameter(Mandatory = $true)][string]$EntityName,
        [Parameter(Mandatory = $true)][string]$OperationName
    )

    switch ($OperationName) {
        "Create"  { return "Guid" }
        "Update"  { return "Unit" }
        "Delete"  { return "Unit" }
        "GetById" { return "${EntityName}Dto" }
        "GetAll"  { return "List<${EntityName}Dto>" }
    }
}

function Generate-Feature {
    <#
        الدالة الرئيسية اللي بتجمع كل حاجة: بتحسب الأسماء، بتنشئ الفولدرات،
        وبتولد كل الملفات المطلوبة للعملية المحددة
    #>
    param(
        [Parameter(Mandatory = $true)][string]$EntityName,
        [Parameter(Mandatory = $true)][string]$OperationName
    )

    $isCommand  = $OperationName -in @("Create", "Update", "Delete")
    $typeFolder = if ($isCommand) { "Command" } else { "Query" }
    $requestSuffix = if ($isCommand) { "Command" } else { "Query" }

    $classPrefix  = Get-ClassPrefix -EntityName $EntityName -OperationName $OperationName
    $responseType = Get-ResponseType -EntityName $EntityName -OperationName $OperationName
    $namespace    = "$RootNamespace.Features.${EntityName}s.$typeFolder.$classPrefix"

    $entityFolder  = Join-Path $ApplicationPath "Features\${EntityName}s"
    $groupFolder   = Join-Path $entityFolder $typeFolder
    $featureFolder = Join-Path $groupFolder $classPrefix

    Create-Directory -Path $featureFolder

    $tokens = @{
        Entity       = $EntityName
        Namespace    = $namespace
        ResponseType = $responseType
        ClassPrefix  = $classPrefix
    }

    # -------- Command / Query --------
    $requestTemplate = Get-Template -OperationName $OperationName -FileName "$requestSuffix.tpl"
    $requestContent  = Replace-Tokens -Content $requestTemplate -Tokens $tokens
    Generate-File -Path (Join-Path $featureFolder "$classPrefix$requestSuffix.cs") -Content $requestContent

    # -------- Handler --------
    $handlerTemplate = Get-Template -OperationName $OperationName -FileName "Handler.tpl"
    $handlerContent  = Replace-Tokens -Content $handlerTemplate -Tokens $tokens
    Generate-File -Path (Join-Path $featureFolder "${classPrefix}Handler.cs") -Content $handlerContent

    # -------- Validator (بس للـ Commands) --------
    if ($isCommand) {
        $validatorTemplate = Get-Template -OperationName $OperationName -FileName "Validator.tpl"
        $validatorContent  = Replace-Tokens -Content $validatorTemplate -Tokens $tokens
        Generate-File -Path (Join-Path $featureFolder "${classPrefix}Validator.cs") -Content $validatorContent
    }

    Write-Host ""
    Write-Host "تم توليد: $classPrefix ($OperationName)" -ForegroundColor Cyan
    Write-Host "المسار: $featureFolder" -ForegroundColor Cyan
    Write-Host ""
}

# ============================================================
#  التنفيذ
# ============================================================

Write-Host "==================================================" -ForegroundColor Cyan
Write-Host " CQRS Feature Generator - CraftIQ" -ForegroundColor Cyan
Write-Host " Entity: $Entity | Operation: $Operation" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
Write-Host ""

try {
    if (-not (Test-Path $ApplicationPath)) {
        throw "المسار غير موجود: $ApplicationPath (تأكد من قيمة -ApplicationPath)"
    }

    Generate-Feature -EntityName $Entity -OperationName $Operation

    Write-Host "تم بنجاح ✅" -ForegroundColor Green
}
catch {
    Write-Host ""
    Write-Host "[ERROR] $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}
