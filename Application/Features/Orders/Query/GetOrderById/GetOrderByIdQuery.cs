using CraftIQ_Project.Application.Features.Orders;
using MediatR;

namespace CraftIQ.Application.Features.Orders.Query.GetOrderById;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public Guid Id { get; set; }
    public GetOrderByIdQuery(Guid ID)
    {
        Id = ID;
    }
}

