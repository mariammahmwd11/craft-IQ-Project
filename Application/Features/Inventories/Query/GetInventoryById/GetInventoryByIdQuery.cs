using CraftIQ_Project.Application.Features.Inventorys;
using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Query.GetInventoryById;

public class GetInventoryByIdQuery : IRequest<InventoryDto>
{
    public Guid Id { get; set; }
    public GetInventoryByIdQuery(Guid Id)
    {
        this.Id = Id;
    }
}

