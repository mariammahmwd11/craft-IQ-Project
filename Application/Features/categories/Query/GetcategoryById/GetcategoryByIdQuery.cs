using CraftIQ_Project.Application.Features.categories;
using MediatR;

namespace CraftIQ.Application.Features.categorys.Query.GetcategoryById;

public class GetcategoryByIdQuery : IRequest<categoryDto>
{
    public Guid Id { get; set; }
    public GetcategoryByIdQuery(Guid ID)
    {
        Id= ID;
    }
}

