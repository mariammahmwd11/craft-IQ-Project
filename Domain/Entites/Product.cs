using Domain.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CraftIQ.Domain.Entites
{
    public class Product : BaseEntity
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
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category category { get; set; }=new();

        public int InventoryId { get; set; }
        public Inventory inventory { get; set; } = new();

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = new();

        public List<OrderDetail> orderDetails { get; set; } = new();
        public Product() { }

        public Product(string name,
                       string description,
                       decimal unitPrice,
                       float weight,
                       float length,
                       float width,
                       float height,
                       decimal taxCost,
                       decimal profitPerUnit,
                       decimal productionCost)
        {
            ProductId = Guid.NewGuid();
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            Weight = weight;
            Length = length;
            Width = width;
            Height = height;
            TaxCost = taxCost;
            ProfitPerUnit = profitPerUnit;
            ProductionCost = productionCost;
            CreatedBy = new();
            CreatedOn = DateTimeOffset.Now;
            ModifiedBy = new();
            ModifiedOn = DateTimeOffset.Now;
        }

        public void SetCategory(Category category) =>
          this.category = category;

        public void SetInventory(Inventory inventory) =>
            this.inventory = inventory;

        public void SetTransaction(Transaction transaction) =>
            Transaction = transaction;

        public void UpdateProduct(string name,
                                  string description,
                                  decimal unitPrice,
                                  float weight,
                                  float length,
                                  float width,
                                  float height,
                                  decimal taxCost,
                                  decimal profitPerUnit,
                                  decimal productionCost,
                                  Guid modifiedBy)
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            Weight = weight;
            Length = length;
            Width = width;
            Height = height;
            TaxCost = taxCost;
            ProfitPerUnit = profitPerUnit;
            ProductionCost = productionCost;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTimeOffset.Now;

        }


    }
}