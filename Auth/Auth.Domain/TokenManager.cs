namespace Demo.Auth.Domain;

public class TokenManager(string key)
{
    public string Key => key;
}