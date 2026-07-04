using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.categories.Specification;
using MediatR;

namespace CraftIQ.Application.Features.categorys.Command.Updatecategory;

public class UpdatecategoryHandler : IRequestHandler<UpdatecategoryCommand>
{
    private readonly IRepository<Category> repository;

    public UpdatecategoryHandler(IRepository<Category>repository)
    {
        this.repository = repository;
    }

    public async Task Handle(UpdatecategoryCommand request, CancellationToken cancellationToken)
    {
      var spec=new GetCategoryByIDSpecification(request.Id);
        var category =await repository.FirstOrDefaultAsync(spec,cancellationToken);
        if(category == null)
        {
            throw new Exception($"Category with ID {request.Id} not found.");
        }
        category.UpdateCategory(request.Name, request.Description, request.ModifiedBy);
        await repository.UpdateAsync(category);
       
    }
}

