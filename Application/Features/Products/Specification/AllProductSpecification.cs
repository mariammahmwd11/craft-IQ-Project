using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Specification
{
    public class AllProductSpecification:Specification<CraftIQ.Domain.Entites.Product>
    {
        public AllProductSpecification()
        {
            Query.Include(p => p.category)
                 .Include(p => p.inventory)
                 .Include(p => p.Transaction);
        }
    }
}
