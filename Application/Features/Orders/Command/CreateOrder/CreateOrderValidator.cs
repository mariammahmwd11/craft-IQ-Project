using FluentValidation;

namespace CraftIQ.Application.Features.Orders.Command.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required.");
        RuleFor(x => x.SupplierId).NotEmpty().WithMessage("SupplierId is required.");
        RuleFor(x => x.OrderDate).NotEmpty().WithMessage("OrderDate is required.");
        RuleFor(x => x.ExpectedDeliveryDate).NotEmpty().WithMessage("ExpectedDeliveryDate is required.");
        RuleFor(x=>x.ReceivedDate).NotEmpty().WithMessage("ReceivedDate is required.");
        RuleFor(x => x.TotalAmount).GreaterThan(0).WithMessage("TotalAmount must be greater than 0.");
        RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required.");
    }
}

