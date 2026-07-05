using Application.Interfaces;
using CraftIQ.Domain.Entites;
using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Command.CreateInventory;

public class CreateInventoryHandler : IRequestHandler<CreateInventoryCommand, Guid>
{
    private readonly IRepository<Inventory> repository;

    public CreateInventoryHandler(IRepository<Inventory> repository)
    {
        this.repository = repository;
    }
    public async Task<Guid> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
       
        var inventory = new Inventory(request.Quantity, request.ReorderLevel, request.lastUpdated,request.Location,request.Name);
        await repository.AddAsync(inventory);
        await repository.SaveChangesAsync();
        return inventory.InventoryId;

    }
}

