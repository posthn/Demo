namespace Demo.Auth.Domain.Models;

public class AuthData
{
    public string Login { get; set; }

    public string PasswordHash { get; set; }

    private AuthData() { }

    public AuthData(string login, string passwordHash)
    {
        Login = login;
        PasswordHash = passwordHash;
    }

    public static Expression<Func<AuthData, bool>> FilterByLogin(string login)
        => x => string.Compare(x.Login, login, true) == 0;
}