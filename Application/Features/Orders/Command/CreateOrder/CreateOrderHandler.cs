using Application.Interfaces;
using CraftIQ.Domain.Entites;
using MediatR;

namespace CraftIQ.Application.Features.Orders.Command.CreateOrder;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IRepository<Order> repository;

    public CreateOrderHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
      var order=new Order
      {
          OrderId = request.OrderId,
          SupplierId = request.SupplierId,
          OrderDate = request.OrderDate,
          ExpectedDeliveryDate = request.ExpectedDeliveryDate,
          ReceivedDate = request.ReceivedDate,
          TotalAmount = request.TotalAmount,
          Status = request.Status,
          OrderType = request.OrderType
      };
        await repository.AddAsync(order);
        await repository.SaveChangesAsync();
        return order.OrderId;

    }
}

