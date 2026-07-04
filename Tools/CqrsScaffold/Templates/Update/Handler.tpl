using MediatR;

namespace {{Namespace}};

public class {{ClassPrefix}}Handler : IRequestHandler<{{ClassPrefix}}Command, {{ResponseType}}>
{
    public Task<{{ResponseType}}> Handle({{ClassPrefix}}Command request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
