using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Orders;
using CraftIQ_Project.Application.Features.Orders.Specification;
using MediatR;

namespace CraftIQ.Application.Features.Orders.Query.GetAllOrder;

public class GetAllOrderHandler : IRequestHandler<GetAllOrderQuery, List<OrderDto>>
{
    private readonly IRepository<Order> repository;

    public GetAllOrderHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }
    public async Task<List<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var spec = new AllOrdersSpecification();
        var orders =await repository.ListAsync(spec);
        var orderDtos = orders.Select(order => new OrderDto
        {
            OrderId = order.OrderId,
            SupplierId = order.SupplierId,
            OrderDate = order.OrderDate,
            ExpectedDeliveryDate = order.ExpectedDeliveryDate,
            ReceivedDate = order.ReceivedDate,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            OrderType = order.OrderType
        }).ToList();

        return orderDtos;
    }
}

