using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Orders.Specification;
using MediatR;
using Microsoft.VisualBasic;

namespace CraftIQ.Application.Features.Orders.Command.DeleteOrder;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IRepository<Order> repository;

    public DeleteOrderHandler(IRepository<Order> repository)
    {
        this.repository = repository;
    }

    async Task IRequestHandler<DeleteOrderCommand>.Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var spec=new OrderByIdSpecification(request.Id);
        var order =await repository.FirstOrDefaultAsync(spec, cancellationToken);
       await repository.DeleteAsync(order);
        await repository.SaveChangesAsync();
    }
}

