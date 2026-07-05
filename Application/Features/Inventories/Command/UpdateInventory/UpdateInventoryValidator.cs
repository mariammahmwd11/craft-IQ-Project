using FluentValidation;

namespace CraftIQ.Application.Features.Inventorys.Command.UpdateInventory;

public class UpdateInventoryValidator : AbstractValidator<UpdateInventoryCommand>
{
    public UpdateInventoryValidator()
    {
        RuleFor(x => x.InventoryId)
            .NotEmpty().WithMessage("Inventory ID is required.");
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.")
           .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
        RuleFor(x => x.Quantity)
             .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0.");
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");
    }
}

