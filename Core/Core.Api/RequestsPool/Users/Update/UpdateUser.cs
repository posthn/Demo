namespace Demo.Core.Api.RequestsPool.Users.Update;

public class UpdateUser : RequestBase<UserResponse?>
{
    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public bool HasValues => Login is null && Password is null && Fullname is null;
}