namespace Demo.Users.Domain.Models;

public class User : LogicalDeletation
{
    public long Id { get; }

    public string Login { get; set; }

    public string FullName { get; set; }

    private User() { }

    public User(string login, string fullName)
    {
        Login = login;
        FullName = fullName;
    }

    public static Expression<Func<User, bool>> FilterById(long id)
        => u => u.Id == id;

    public static Expression<Func<User, bool>> FilterByLogin(string login)
        => u => u.Login.ToLower() == login.ToLower();
}