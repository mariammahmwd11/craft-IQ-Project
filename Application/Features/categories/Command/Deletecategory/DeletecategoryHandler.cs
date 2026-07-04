using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.categories.Specification;
using MediatR;

namespace CraftIQ.Application.Features.categorys.Command.Deletecategory;

public class DeletecategoryHandler : IRequestHandler<DeletecategoryCommand>
{
    private readonly IRepository<Category> repository;

    public DeletecategoryHandler(IRepository<Category> repository)
    {
        this.repository = repository;
    }
    public async Task Handle(DeletecategoryCommand request, CancellationToken cancellationToken)
    {
        var spec=new GetCategoryByIDSpecification(request.Id);
        var category =await repository.FirstOrDefaultAsync(spec, cancellationToken);
        await repository.DeleteAsync(category);
        await repository.SaveChangesAsync();
    }
}

