using CraftIQ.Application.Features.Products.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Query.GetProductById
{
    public class GetProductByIdQuery:IRequest<ProductDTO>
    {
        public Guid ProductId { get; set; }
        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
   
}
