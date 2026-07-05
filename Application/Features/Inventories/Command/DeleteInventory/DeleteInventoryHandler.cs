using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Inventorys.Specifications;
using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Command.DeleteInventory;

public class DeleteInventoryHandler : IRequestHandler<DeleteInventoryCommand>
{
    private readonly IRepository<Inventory> repository;

    public DeleteInventoryHandler(IRepository<Inventory> repository)
    {
        this.repository = repository;
    }
    public async Task Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
    {
       var spc=new GetInventoryByIDSpecification(request.Id);
        var inventory =await repository.FirstOrDefaultAsync(spc, cancellationToken);
        if(inventory == null)
        {
            throw new Exception($"Inventory with ID {request.Id} not found.");
        }
        await repository.DeleteAsync(inventory);
        await repository.SaveChangesAsync();
    }
}

