using Application.Interfaces;
using CraftIQ.Application.Features.Products.Query;
using CraftIQ.Application.Features.Products.Query.GetProductById;
using CraftIQ.Application.Features.Products.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Query.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IRepository<Domain.Entites.Product> repository;

        public GetProductByIdHandler(IRepository<CraftIQ.Domain.Entites.Product> repository)
        {
            this.repository = repository;
        }
        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var spc=new ProductByIdSpecification(request.ProductId);
            var product =await repository.FirstOrDefaultAsync(spc);
            var productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                Weight = product.Weight,
                Height = product.Height,
                Length = product.Length,
                Width = product.Width,
                TaxCost = product.TaxCost,
                ProfitPerUnit = product.ProfitPerUnit,
                ProductionCost = product.ProductionCost,
                CategoryId = product.CategoryId,
                InventoryId = product.InventoryId,
                TransactionId = product.TransactionId
            };
            return productDTO;
        }
    }
}
