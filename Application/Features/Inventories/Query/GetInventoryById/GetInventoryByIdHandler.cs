using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Inventorys;
using CraftIQ_Project.Application.Features.Inventorys.Specifications;
using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Query.GetInventoryById;

public class GetInventoryByIdHandler : IRequestHandler<GetInventoryByIdQuery, InventoryDto>
{
    private readonly IRepository<Inventory> repository;

    public GetInventoryByIdHandler(IRepository<Inventory> repository)
    {
        this.repository = repository;
    }
    public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetInventoryByIDSpecification(request.Id);
        var inventory = await repository.FirstOrDefaultAsync(spec, cancellationToken);
        var inventoryDto = new InventoryDto
        {
            InventoryId = inventory.InventoryId,
            Location = inventory.Location,
            Name = inventory.Name,
            lastUpdated = inventory.lastUpdated,
            ReorderLevel = inventory.ReorderLevel,
            Quantity = inventory.Quantity
        };
        return inventoryDto;
    }
}

