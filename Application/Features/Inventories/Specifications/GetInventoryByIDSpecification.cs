using Ardalis.Specification;
using CraftIQ.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.Inventorys.Specifications
{
    public class GetInventoryByIDSpecification:SingleResultSpecification<Inventory>
    {
        public GetInventoryByIDSpecification(Guid ID)
        {
            Query.Where(c => c.InventoryId == ID)
                .Include(c => c.Products);
        }
    }
    
}
