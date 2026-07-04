using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.categories;
using CraftIQ_Project.Application.Features.categories.Specification;
using MediatR;

namespace CraftIQ.Application.Features.categorys.Query.GetcategoryById;

public class GetcategoryByIdHandler : IRequestHandler<GetcategoryByIdQuery, categoryDto>
{
    private readonly IRepository<Category> repository;

    public GetcategoryByIdHandler(IRepository<Category> repository)
    {
        this.repository = repository;
    }
    public async Task<categoryDto> Handle(GetcategoryByIdQuery request, CancellationToken cancellationToken)
    {
      var spec=new GetCategoryByIDSpecification(request.Id);
        var category =await repository.FirstOrDefaultAsync(spec, cancellationToken);
        return new categoryDto
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            Description = category.Description
        };
    }
}

