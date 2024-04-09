namespace Demo.Core.Api.ResponsesPool;

public class ResponseList<TResult>
{
    public IList<TResult>? ResultList { get; set; }

    public long Count { get; set; }

    public int PageNumber { get; set; }

    public short PageSize { get; set; }
}