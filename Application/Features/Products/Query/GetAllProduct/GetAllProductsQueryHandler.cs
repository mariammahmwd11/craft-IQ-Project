using Application.Interfaces;
using CraftIQ.Application.Features.Products.Query;
using CraftIQ.Application.Features.Products.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Query.GetAllProduct
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly IRepository<Domain.Entites.Product> repository;

        public GetAllProductsQueryHandler(IRepository<CraftIQ.Domain.Entites.Product> repository )
        {
            this.repository = repository;
        }
        public Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var spc=new AllProductSpecification();
            var products = repository.ListAsync(spc);
            var productDTOs = products.Result.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                Weight = p.Weight,
                Height = p.Height,
                Length = p.Length,
                Width = p.Width,
                TaxCost = p.TaxCost,
                ProfitPerUnit = p.ProfitPerUnit,
                ProductionCost = p.ProductionCost,
                CategoryId = p.CategoryId,
                InventoryId = p.InventoryId,
                TransactionId = p.TransactionId
            }).ToList();

            return Task.FromResult(productDTOs);
        }
    }
}
