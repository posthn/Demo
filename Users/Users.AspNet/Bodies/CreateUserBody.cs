namespace Demo.Users.AspNet.Bodies;

public class CreateUserBody
{
    public string Login { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }
}