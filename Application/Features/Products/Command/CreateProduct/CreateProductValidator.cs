using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x=>x.ProductId)
                .NotEmpty().WithMessage("Product Id is required.");
            RuleFor(x=>x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(50).WithMessage("Product name cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Product description cannot exceed 200 characters.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than 0.");

            RuleFor(x => x.ProductionCost)
                .GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");

            RuleFor(x => x.ProfitPerUnit)
                .GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");

           


        }
    }
}
