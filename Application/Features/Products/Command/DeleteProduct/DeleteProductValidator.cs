using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductValidator:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.ProductId)
               .NotEmpty();
               
        }
    }
}
