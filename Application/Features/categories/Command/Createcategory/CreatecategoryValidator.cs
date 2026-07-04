using FluentValidation;

namespace CraftIQ.Application.Features.categorys.Command.Createcategory;

public class CreatecategoryValidator : AbstractValidator<CreatecategoryCommand>
{
    public CreatecategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

    }
}

