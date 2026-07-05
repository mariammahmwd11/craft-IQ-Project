using Ardalis.Specification;
using CraftIQ.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.Inventorys.Specifications
{
    public class GetAllInventoriesSpecification:Specification<Inventory>
    {
        public GetAllInventoriesSpecification()
        {
            Query.Include(i => i.Products);
               
        }
    }
}
