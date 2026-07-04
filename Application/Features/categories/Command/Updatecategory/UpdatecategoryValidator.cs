using FluentValidation;

namespace CraftIQ.Application.Features.categorys.Command.Updatecategory;

public class UpdatecategoryValidator : AbstractValidator<UpdatecategoryCommand>
{
    public UpdatecategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID is required.");
        RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Name is required.")
          .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}

