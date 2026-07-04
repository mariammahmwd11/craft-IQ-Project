using Application.Interfaces;
using CraftIQ.Domain.Entites;
using MediatR;

namespace CraftIQ.Application.Features.categorys.Command.Createcategory;

public class CreatecategoryHandler : IRequestHandler<CreatecategoryCommand, Guid>
{
    private readonly IRepository<Category> repository;

    public CreatecategoryHandler(IRepository<Category> repository)
    {
        this.repository = repository;
    }
    public async Task<Guid> Handle(CreatecategoryCommand request, CancellationToken cancellationToken)
    {
       var category = new Category(request.Name, request.Description);
       await repository.AddAsync(category);
        await repository.SaveChangesAsync();
        return category.CategoryId;
    }
}

