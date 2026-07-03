using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommand:IRequest
    {
        public Guid ProductId { get; set; }
        public DeleteProductCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
