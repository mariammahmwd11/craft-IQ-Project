using Application.Interfaces;
using CraftIQ.Application.Features.Products.Command.UpdateProduct;
using CraftIQ.Application.Features.Products.Specification;
using CraftIQ.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ_Project.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> repository;

        public UpdateProductHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }
       
        async Task IRequestHandler<UpdateProductCommand>.Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new ProductByIdSpecification(request.ProductId);
            var product =await repository.FirstOrDefaultAsync(spec);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.UpdateProduct(request.Name,
                request.Description,
                request.UnitPrice,
                request.Weight,
                request.Length,
                request.Width,
                request.Height,
                request.TaxCost,
                request.ProfitPerUnit,
                request.ProductionCost,
                request.ModifiedBy);
            await repository.UpdateAsync(product);
            await repository.SaveChangesAsync();

        }
    }
}
