using MediatR;

namespace {{Namespace}};

public class {{ClassPrefix}}Query : IRequest<{{ResponseType}}>
{
    public Guid Id { get; set; }
}
