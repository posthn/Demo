namespace Demo.Core.Api.RequestsPool.Users.Create;

public class CreateUser : IRequest<UserResponse?>
{
    public string Login { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }
}