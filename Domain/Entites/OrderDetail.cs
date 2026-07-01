using Domain.Entites;
using System.ComponentModel.DataAnnotations.Schema;

namespace CraftIQ.Domain.Entites
{
    public class OrderDetail:BaseEntity
    {
        public Guid OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
        [ForeignKey("OrderId")]
        public Order order { get; set; } = new();
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public OrderDetail() { }
       
        public OrderDetail(int quantity,decimal totalPrice)
        {
            OrderDetailsId= Guid.NewGuid();
            Quantity = quantity;
            TotalPrice = totalPrice;
            CreatedBy = new();
            ModifiedBy = new();
            CreatedOn = DateTimeOffset.Now;
            ModifiedOn = DateTimeOffset.Now;
        }
        public void UpdateOrderDetail(int quantity, decimal totalPrice, Guid modifiedBy)
        {
            Quantity = quantity;
            TotalPrice = totalPrice;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTimeOffset.Now;
        }
        public void SetProduct(Product product) =>
            Product = product;

        public void SetOrder(Order order) =>
            this.order = order;
    }
}