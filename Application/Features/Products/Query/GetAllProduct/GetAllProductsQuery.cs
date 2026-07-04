using CraftIQ_Project.Application.Features.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Query.GetAllProduct
{
    public record GetAllProductsQuery:IRequest<List<ProductDTO>>
    {

    }
}
