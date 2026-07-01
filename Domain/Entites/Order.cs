using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Domain.Entites
{
    public class Order:BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid SupplierId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset ExpectedDeliveryDate { get; set; }
        public DateTimeOffset ReceivedDate { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }
        public String? OrderType { get; set; }
        public List<OrderDetail> orderDetails { get; set; } = new();

        public Order() { }
        
        public Order(DateTimeOffset orderDate,
            DateTimeOffset expectedDeliveryDate,
            DateTimeOffset receivedDate,
           int totalAmount, int status,
           String orderType)
        {
            OrderId= Guid.NewGuid();
            orderDate = orderDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
            ReceivedDate= receivedDate;
            TotalAmount = totalAmount;
            Status = status;
            OrderType = orderType;

            ModifiedBy = new();
            ModifiedOn = DateTimeOffset.Now;
            CreatedBy = new();
            CreatedOn = DateTimeOffset.Now;
        }

        public void UpdateOrder(DateTimeOffset orderDate,
            DateTimeOffset expectedDeliveryDate,
            DateTimeOffset receivedDate,
           int totalAmount, int status,
           String orderType, Guid modifiedBy)
        {
            OrderDate = orderDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
            ReceivedDate = receivedDate;
            TotalAmount = totalAmount;
            Status = status;
            OrderType = orderType;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTimeOffset.Now;
        }
        
    }
}
