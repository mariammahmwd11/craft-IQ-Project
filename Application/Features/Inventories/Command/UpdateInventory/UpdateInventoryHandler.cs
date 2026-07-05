using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Inventorys.Specifications;
using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Command.UpdateInventory;

public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand>
{
    private readonly IRepository<Inventory> repository;

    public UpdateInventoryHandler(IRepository<Inventory> repository)
    {
        this.repository = repository;
    }
    public async Task Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var spec=new GetInventoryByIDSpecification(request.InventoryId);
        var inventory =await repository.FirstOrDefaultAsync(spec, cancellationToken);
        inventory.UpdateInventory(request.Quantity, request.ReorderLevel, request.lastUpdated, request.Location, request.Name, request.ModifiedBy);
        await repository.SaveChangesAsync();

    }
}

