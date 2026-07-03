using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Specification
{
    public class ProductByIdSpecification:SingleResultSpecification<Domain.Entites.Product>
    {
        public ProductByIdSpecification(Guid productId)
        {
            Query.Where(x=>x.ProductId == productId)
                 .Include(x => x.category)
                .Include(x => x.inventory)
                .Include(x=>x.Transaction); 
        }
    }
}
