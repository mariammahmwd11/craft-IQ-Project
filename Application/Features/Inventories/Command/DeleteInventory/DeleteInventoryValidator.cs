using FluentValidation;

namespace CraftIQ.Application.Features.Inventorys.Command.DeleteInventory;

public class DeleteInventoryValidator : AbstractValidator<DeleteInventoryCommand>
{
    public DeleteInventoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Inventory ID is required.");
    }
}

