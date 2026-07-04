using MediatR;

namespace CraftIQ.Application.Features.categorys.Command.Deletecategory;

public class DeletecategoryCommand : IRequest
{
    public Guid Id { get; set; }
    public DeletecategoryCommand(Guid id)
    {
        Id = id;
    }
}

