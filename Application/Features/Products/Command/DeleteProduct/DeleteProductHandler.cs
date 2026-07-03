using Application.Interfaces;
using CraftIQ.Application.Features.Products.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CraftIQ.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductHandler
    : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Domain.Entites.Product> repository;

        public DeleteProductHandler(IRepository<CraftIQ.Domain.Entites.Product> repository)
        {
            this.repository = repository;
        }
       

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new ProductByIdSpecification(request.ProductId);
            var product =await repository.FirstOrDefaultAsync(spec);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            await repository.DeleteAsync(product);
            await repository.SaveChangesAsync();
        }
    }
}
