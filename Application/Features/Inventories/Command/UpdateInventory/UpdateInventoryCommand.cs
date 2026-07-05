using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Command.UpdateInventory;

public class UpdateInventoryCommand : IRequest
{
    public Guid InventoryId { get; set; }
    public int Quantity { get; set; }
    public int ReorderLevel { get; set; }
    public DateTimeOffset lastUpdated { get; set; }
    public string? Location { get; set; }
    public string Name { get; set; }
    public Guid ModifiedBy { get; set; }
}

