using MediatR;

namespace CraftIQ.Application.Features.categorys.Command.Createcategory;

public class CreatecategoryCommand : IRequest<Guid>
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

