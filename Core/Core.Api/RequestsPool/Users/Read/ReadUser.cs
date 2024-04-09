namespace Demo.Core.Api.RequestsPool.Users.Read;

public class ReadUser : IRequest<UserResponse?>
{
    public long? Id { get; set; }

    public string? Login { get; set; }

    public bool IsValidRequest => Id.HasValue ^ Login is not null;
}