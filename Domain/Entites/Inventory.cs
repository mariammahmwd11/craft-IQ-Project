using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Domain.Entites
{
    public class Inventory:BaseEntity
    {
        public Guid InventoryId { get; set; }
        public int Quantity { get; set; }
        public int ReorderLevel { get; set; }
        public DateTimeOffset lastUpdated { get; set; }
        public string? Location { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();

        public Inventory() { }
        
        public Inventory
            (int Quantity, int ReorderLevel, DateTimeOffset lastUpdated, string Location, string Name)
        {this.InventoryId = Guid.NewGuid();
            this.Quantity = Quantity;
            this.ReorderLevel = ReorderLevel;
            this.lastUpdated = lastUpdated;
            this.Location = Location;
            this.Name = Name;
            
            CreatedBy=new();
            CreatedOn = DateTimeOffset.Now;
            ModifiedBy = new();
            ModifiedOn = DateTimeOffset.Now;

        }

        public void UpdateInventory(int Quantity, int ReorderLevel, DateTimeOffset lastUpdated, string Location, string Name, Guid modifiedBy)
        {
            this.Quantity = Quantity;
            this.ReorderLevel = ReorderLevel;
            this.lastUpdated = lastUpdated;
            this.Location = Location;
            this.Name = Name;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTimeOffset.Now;
        }
    }
}
