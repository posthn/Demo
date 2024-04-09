namespace Demo.Core.Api.RequestsPool.Auth.Update;

public class UpdateAuthData : IRequest<Unit>
{
    public string CurrentLogin { get; set; }

    public string? NewLogin { get; set; }

    public string? NewPassword { get; set; }
}