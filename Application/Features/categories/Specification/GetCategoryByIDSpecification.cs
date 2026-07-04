using Ardalis.Specification;
using CraftIQ.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.categories.Specification
{
    public class GetCategoryByIDSpecification:SingleResultSpecification<Category>
    {
        public GetCategoryByIDSpecification(Guid ID)
        {

            Query.Where(c => c.CategoryId == ID)
                .Include(c=>c.Products);
        }
    }
}
