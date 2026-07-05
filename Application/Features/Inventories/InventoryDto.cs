namespace CraftIQ_Project.Application.Features.Inventorys
{
    public class InventoryDto
    {
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public DateTimeOffset lastUpdated { get; set; }
        public string? Location { get; set; }
        public string Name { get; set; }
    }
}