using CraftIQ_Project.Application.Features.Orders;
using MediatR;

namespace CraftIQ.Application.Features.Orders.Query.GetAllOrder;

public class GetAllOrderQuery : IRequest<List<OrderDto>>
{
}

