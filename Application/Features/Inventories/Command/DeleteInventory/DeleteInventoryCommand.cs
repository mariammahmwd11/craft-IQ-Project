using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Command.DeleteInventory;

public class DeleteInventoryCommand : IRequest
{
    public Guid Id { get; set; }
    public DeleteInventoryCommand(Guid Id)
    {
        this.Id = Id;
    }
}

