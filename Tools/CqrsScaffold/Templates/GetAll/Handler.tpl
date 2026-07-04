using MediatR;

namespace {{Namespace}};

public class {{ClassPrefix}}Handler : IRequestHandler<{{ClassPrefix}}Query, {{ResponseType}}>
{
    public Task<{{ResponseType}}> Handle({{ClassPrefix}}Query request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
