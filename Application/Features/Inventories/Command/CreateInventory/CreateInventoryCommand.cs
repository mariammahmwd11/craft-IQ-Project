using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Command.CreateInventory;

public class CreateInventoryCommand : IRequest<Guid>
{
    public Guid InventoryId { get; set; }
    public int Quantity { get; set; }
    public int ReorderLevel { get; set; }
    public DateTimeOffset lastUpdated { get; set; }
    public string? Location { get; set; }
    public string Name { get; set; }
}

