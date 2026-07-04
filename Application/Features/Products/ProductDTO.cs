using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.Products
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public decimal TaxCost { get; set; }
        public decimal ProfitPerUnit { get; set; }
        public decimal ProductionCost { get; set; }
        public int? CategoryId { get; set; }

        public int? InventoryId { get; set; }

        public int? TransactionId { get; set; }
    }
}
