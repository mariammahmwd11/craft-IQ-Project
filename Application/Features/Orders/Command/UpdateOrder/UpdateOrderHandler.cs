using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Orders.Specification;
using MediatR;

namespace CraftIQ.Application.Features.Orders.Command.UpdateOrder;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IRepository<Order> repository;

    public UpdateOrderHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }
    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var spec = new OrderByIdSpecification(request.OrderId);
        var order =await repository.FirstOrDefaultAsync(spec);
       if(order == null)
        {
            throw new Exception("Order not found");
        }
        order.UpdateOrder(
            request.OrderDate,
            request.ExpectedDeliveryDate,
            request.ReceivedDate,
            request.TotalAmount,
            request.Status,
            request.OrderType
            , request.ModifiedBy);


    }
}

