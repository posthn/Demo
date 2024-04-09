namespace Demo.Core.Api.RequestsPool.Auth.Create;

public class CreateAuthData : IRequest<Unit>
{
    public string Login { get; set; }

    public string Password { get; set; }
}