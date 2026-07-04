using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Orders;
using CraftIQ_Project.Application.Features.Orders.Specification;
using MediatR;

namespace CraftIQ.Application.Features.Orders.Query.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IRepository<Order> repository;

    public GetOrderByIdHandler(IRepository<Order>repository)
    {
        this.repository = repository;
    }
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var spec=new OrderByIdSpecification(request.Id);
        var order =await repository.FirstOrDefaultAsync(spec);
        return new OrderDto
        {
            OrderId = order.OrderId,
            SupplierId = order.SupplierId,
            OrderDate = order.OrderDate,
            ExpectedDeliveryDate = order.ExpectedDeliveryDate,
            ReceivedDate = order.ReceivedDate,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            OrderType = order.OrderType
        };
    }
}

