using MediatR;

namespace {{Namespace}};

public class {{ClassPrefix}}Command : IRequest<{{ResponseType}}>
{
    public Guid Id { get; set; }
}
