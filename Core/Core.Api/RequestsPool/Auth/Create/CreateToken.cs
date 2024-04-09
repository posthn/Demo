namespace Demo.Core.Api.RequestsPool.Auth.Create;

public class CreateToken : IRequest<TokenResponse?>
{
    public string Login { get; set; }

    public string Password { get; set; }
}