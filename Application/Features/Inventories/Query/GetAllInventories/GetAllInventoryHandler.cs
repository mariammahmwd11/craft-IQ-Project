using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.Inventorys;
using CraftIQ_Project.Application.Features.Inventorys.Specifications;
using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Query.GetAllInventory;

public class GetAllInventoryHandler : IRequestHandler<GetAllInventoryQuery, List<InventoryDto>>
{
    private readonly IRepository<Inventory> repository;

    public GetAllInventoryHandler(IRepository<Inventory> repository)
    {
        this.repository = repository;
    }
    public async Task<List<InventoryDto>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetAllInventoriesSpecification();
        var inventorys =await repository.ListAsync(spec, cancellationToken);
        return inventorys.Select(i => new InventoryDto
        {
            InventoryId = i.InventoryId,
            lastUpdated = i.lastUpdated,
            Quantity = i.Quantity,
            ReorderLevel = i.ReorderLevel,
            Location = i.Location,
            Name = i.Name
        }).ToList();

    }
}

