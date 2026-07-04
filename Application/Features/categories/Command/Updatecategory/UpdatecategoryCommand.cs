using MediatR;

namespace CraftIQ.Application.Features.categorys.Command.Updatecategory;

public class UpdatecategoryCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ModifiedBy { get; set; }
}

