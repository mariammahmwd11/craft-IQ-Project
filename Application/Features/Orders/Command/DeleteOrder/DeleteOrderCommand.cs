using MediatR;

namespace CraftIQ.Application.Features.Orders.Command.DeleteOrder;

public class DeleteOrderCommand : IRequest
{
    public Guid Id { get; set; }
    public DeleteOrderCommand(Guid id)
    {
        Id= id;
    }
}

