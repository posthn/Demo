namespace Demo.Users.AspNet.Bodies;

public class ReadUserListBody : BodyRequestBase
{
    public string? SubstringFilter { get; set; }
}