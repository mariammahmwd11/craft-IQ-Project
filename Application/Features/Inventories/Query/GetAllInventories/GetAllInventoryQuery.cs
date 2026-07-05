using CraftIQ_Project.Application.Features.Inventorys;
using MediatR;

namespace CraftIQ.Application.Features.Inventorys.Query.GetAllInventory;

public class GetAllInventoryQuery : IRequest<List<InventoryDto>>
{
}

