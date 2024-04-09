namespace Demo.Core.Api.RequestsPool;

public abstract class RequestBase<TResponse> : IRequest<TResponse>
{
    public RequestContext Context { get; } = new();
}

public class RequestContext
{
    public long UserId { get; set; }

    public Pager? Pager { get; set; }
}

