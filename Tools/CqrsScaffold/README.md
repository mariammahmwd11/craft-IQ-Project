# CQRS Feature Generator - CraftIQ

أداة PowerShell بسيطة لتوليد الـ Skeleton بتاع CQRS Features
(Command/Query + Handler + Validator) في مشروع CraftIQ Clean Architecture.

**مهم:** الأداة دي بتعمل Skeleton فاضي بس. مفيش Business Logic،
مفيش Repository calls، مفيش AutoMapper، مفيش Specifications.
كل حاجة انت هتضيفها بنفسك بعد التوليد.

---

## 1) هيكل الأداة

```
CqrsScaffold/
├── New-Feature.ps1          <- السكريبت اللي هتشغله
├── README.md                 <- الملف ده
└── Templates/
    ├── Create/
    │   ├── Command.tpl
    │   ├── Handler.tpl
    │   └── Validator.tpl
    ├── Update/
    │   ├── Command.tpl
    │   ├── Handler.tpl
    │   └── Validator.tpl
    ├── Delete/
    │   ├── Command.tpl
    │   ├── Handler.tpl
    │   └── Validator.tpl
    ├── GetById/
    │   ├── Query.tpl
    │   └── Handler.tpl
    └── GetAll/
        ├── Query.tpl
        └── Handler.tpl
```

**السكريبت لازم يفضل جنب مجلد Templates دايمًا** لإنه بيقرا الـ Templates
بمسار نسبي (`$PSScriptRoot\Templates`). ينفع تحط المجلد كله (CqrsScaffold)
في أي مكان على جهازك - مش لازم يكون جوه الـ Solution بتاع CraftIQ.
مثلاً ينفع تحطه في:

```
C:\Tools\CqrsScaffold\
```

أو حتى على سطح المكتب، مش هيفرق.

---

## 2) أول مرة تشغل PowerShell Script في حياتك؟ اتبع الخطوات دي بالظبط

### أ) افتح PowerShell

- اضغط على زرار Windows، اكتب `PowerShell`، افتح **Windows PowerShell** (أو **PowerShell 7** لو متثبت عندك)
- أو من جوه Visual Studio: **View > Terminal**، وتأكد إنه شغال بـ PowerShell مش cmd

### ب) اسمح بتشغيل السكريبتات (مرة واحدة بس في حياتك)

بشكل افتراضي، Windows بيمنع تشغيل أي `.ps1` لأسباب أمان. عشان تسمح بيه:

```powershell
Set-ExecutionPolicy -Scope CurrentUser RemoteSigned
```

هيسألك تأكيد، اكتب `Y` واضغط Enter.

> **ليه دي آمنة؟** `-Scope CurrentUser` معناها التغيير هيأثر على حسابك انت بس مش كل الجهاز،
> و `RemoteSigned` معناها ينفع تشغل سكريبتات كتبتها انت بنفسك من غير مشاكل،
> لكن السكريبتات اللي جاية من الإنترنت لازم تكون موقعة (Signed) عشان تشتغل.

### ج) روح لمكان السكريبت

```powershell
cd "C:\Tools\CqrsScaffold"
```

(غيّر المسار حسب مكان ما حطيت فيه المجلد فعليًا)

---

## 3) طريقة الاستخدام

### الصيغة العامة

```powershell
.\New-Feature.ps1 -Entity <اسم الـ Entity بالمفرد> -Operation <نوع العملية>
```

### أمثلة لكل عملية مدعومة

```powershell
# إنشاء Create Feature لـ Product
.\New-Feature.ps1 -Entity Product -Operation Create

# إنشاء Update Feature لـ Product
.\New-Feature.ps1 -Entity Product -Operation Update

# إنشاء Delete Feature لـ Product
.\New-Feature.ps1 -Entity Product -Operation Delete

# إنشاء GetById Feature لـ Product
.\New-Feature.ps1 -Entity Product -Operation GetById

# إنشاء GetAll Feature لـ Product
.\New-Feature.ps1 -Entity Product -Operation GetAll
```

### لو عايز تستبدل ملفات موجودة بالفعل

بشكل افتراضي، لو الملف موجود، السكريبت هيتخطاه ويطلعلك تحذير أصفر
عشان محدش يفقد كود كتبه بالغلط. لو عايز فعلاً تستبدل:

```powershell
.\New-Feature.ps1 -Entity Product -Operation Create -Force
```

### لو المسار أو الـ Namespace مختلف عن الافتراضي

```powershell
.\New-Feature.ps1 -Entity Order -Operation Create `
    -ApplicationPath "D:\Projects\MyApp\Application" `
    -RootNamespace "MyApp.Application"
```

(العلامة `` ` `` في آخر السطر في PowerShell معناها "الأمر لسه مكمل في السطر اللي بعده")

---

## 4) شكل الفولدرات والملفات اللي هتتولد

مثال لـ `.\New-Feature.ps1 -Entity Product -Operation Create`:

```
Application/
└── Features/
    └── Products/
        └── Command/
            └── CreateProduct/
                ├── CreateProductCommand.cs
                ├── CreateProductHandler.cs
                └── CreateProductValidator.cs
```

ولو عملت GetById:

```
Application/
└── Features/
    └── Products/
        └── Query/
            └── GetProductById/
                ├── GetProductByIdQuery.cs
                └── GetProductByIdHandler.cs
```

(لاحظ إن GetById/GetAll مالهمش Validator، حسب المتطلبات)

---

## 5) الـ Response Types المستخدمة

| العملية | Response Type | السبب |
|---|---|---|
| Create | `Guid` | بيرجع الـ Id بتاع الـ Entity الجديد |
| Update | `Unit` | معندوش قيمة يرجعها، لكن MediatR محتاج نوع Generic حتى لو "فاضي" |
| Delete | `Unit` | نفس سبب Update |
| GetById | `{Entity}Dto` | مثلاً `ProductDto` - انت هتنشئه بنفسك |
| GetAll | `List<{Entity}Dto>` | قايمة من الـ Dto |

> **ملحوظة عن Unit:** في MediatR، مفيش حاجة اسمها "من غير Response" فعليًا -
> أي Request لازم يرجع نوع معين. `Unit` هو الحل الرسمي لـ MediatR
> لتمثيل "العملية خلصت من غير قيمة راجعة" (زي `void` بس بشكل يتوافق مع الـ Generic
> Interfaces). هتلاقيه موجود جاهز في `MediatR` namespace فمش محتاج تعمله بنفسك.

---

## 6) إزاي تعدّل الأداة لاحقًا

### تغيير شكل الكود الناتج

كل اللي عليك تفتح ملف الـ `.tpl` المناسب في `Templates/{Operation}/`
وتعدل فيه زي ما انت عايز. السكريبت مش هيحتاج أي تعديل.

مثال: لو عايز تضيف `CreatedAt` property لكل الـ Commands، افتح
`Templates/Create/Command.tpl` و `Templates/Update/Command.tpl` وضيفها هناك.

### إضافة Placeholder جديد

1. افتح `New-Feature.ps1`
2. في دالة `Generate-Feature`، ضيف مفتاح جديد في الـ `$tokens` hashtable:
   ```powershell
   $tokens = @{
       Entity       = $EntityName
       Namespace    = $namespace
       ResponseType = $responseType
       ClassPrefix  = $classPrefix
       MyNewToken   = "القيمة بتاعتك"
   }
   ```
3. استخدمه في أي `.tpl` بالشكل: `{{MyNewToken}}`

### إضافة عملية جديدة (مثلاً Archive أو Restore)

1. عمل مجلد جديد `Templates/Archive/` وحط فيه `Command.tpl`, `Handler.tpl`, `Validator.tpl`
2. في `New-Feature.ps1`، ضيف `"Archive"` في الـ `ValidateSet` بتاع `$Operation`
3. ضيف حالة جديدة في `Get-ClassPrefix` و `Get-ResponseType`

---

## 7) لو حصل خطأ

| الخطأ | الحل |
|---|---|
| `running scripts is disabled on this system` | نفّذ الأمر في خطوة 2-ب تاني |
| `Template غير موجود` | تأكد إن مجلد Templates موجود جنب السكريبت |
| `المسار غير موجود` | تأكد من قيمة `-ApplicationPath` أو استخدم القيمة الافتراضية |
| `[SKIP]` ظاهرة للملفات | الملف موجود بالفعل، استخدم `-Force` لو عايز تستبدله |

---

## 8) تذكير مهم

الأداة دي بتعمل **Skeleton بس**. بعد التوليد، محتاج تروح تعمل يدويًا:

- تسجيل الـ Handler في DI (لو مش بيتسجل تلقائي عن طريق `AddMediatR`)
- كتابة اللوجيك الفعلي جوه الـ Handler (Repository calls, Mapping, إلخ)
- إنشاء الـ `{Entity}Dto` لو مش موجود بالفعل (لعمليات GetById/GetAll)
- كتابة الـ Validation Rules الفعلية جوه الـ Validator
