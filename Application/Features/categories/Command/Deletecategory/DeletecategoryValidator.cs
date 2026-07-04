using FluentValidation;

namespace CraftIQ.Application.Features.categorys.Command.Deletecategory;

public class DeletecategoryValidator : AbstractValidator<DeletecategoryCommand>
{
    public DeletecategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.");

    }
}

