using Ardalis.Specification;
using CraftIQ.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.categories.Specification
{
    public class GatAllCategoriesSpecification:Specification<Category>
    {
        public GatAllCategoriesSpecification()
        {
            Query.Include(c => c.Products);
        }
    }
}
