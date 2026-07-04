using Application.Interfaces;
using CraftIQ.Domain.Entites;
using CraftIQ_Project.Application.Features.categories;
using CraftIQ_Project.Application.Features.categories.Specification;
using MediatR;

namespace CraftIQ.Application.Features.categorys.Query.GetAllcategory;

public class GetAllcategoryHandler : IRequestHandler<GetAllcategoryQuery, List<categoryDto>>
{
    private readonly IRepository<Category> repository;

    public GetAllcategoryHandler(IRepository<Category> repository)
    {
        this.repository = repository;
    }
    public async Task<List<categoryDto>> Handle(GetAllcategoryQuery request, CancellationToken cancellationToken)
    {
       var spec=new GatAllCategoriesSpecification();
        var categories =await repository.ListAsync(spec, cancellationToken);
        var categoryDtos = categories.Select(c => new categoryDto
        {
            CategoryId = c.CategoryId,
            Name = c.Name,
            Description = c.Description
        }).ToList();
        return categoryDtos;

    }
}

