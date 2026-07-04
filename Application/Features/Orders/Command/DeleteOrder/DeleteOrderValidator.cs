using FluentValidation;

namespace CraftIQ.Application.Features.Orders.Command.DeleteOrder;

public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Order Id is required.");
    }
}

