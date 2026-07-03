using CraftIQ.Application.Features.Products.Query;
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
