using MediatR;

namespace CraftIQ.Application.Features.Orders.Command.UpdateOrder;

public class UpdateOrderCommand : IRequest
{
  
    public Guid OrderId { get; set; }
    public Guid SupplierId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset ExpectedDeliveryDate { get; set; }
    public DateTimeOffset ReceivedDate { get; set; }
    public int TotalAmount { get; set; }
    public int Status { get; set; }
    public String? OrderType { get; set; }
    public Guid ModifiedBy { get; set; }

}

