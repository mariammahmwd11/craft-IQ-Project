using Ardalis.Specification.EntityFrameworkCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entites;
using Application.Interfaces;

namespace CraftIQ.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IRepository<Domain.Entites.Product> _repository;

        public CreateProductHandler(IRepository<Domain.Entites.Product> repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entites.Product(
                request.Name,
                request.Description,
                request.UnitPrice,
                request.Weight,
                request.Length,
                request.Width,
                request.Height,
                request.TaxCost,
                request.ProfitPerUnit,
                request.ProductionCost
               );

            product.CategoryId = request.CategoryId;
            product.InventoryId = request.InventoryId;
            product.TransactionId = request.TransactionId;

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
            return product.ProductId;

        }
    }
}
