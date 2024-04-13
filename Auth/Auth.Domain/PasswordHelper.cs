using Demo.Auth.Domain.Constants;

namespace Demo.Auth.Domain;

public static class PasswordHelper
{
    public static string GetStringFromBase64(string value)
    {
        value = value.Insert(value.Length - 1, new string('d', 4 - (value.Length % 4)));

        return Encoding.UTF8.GetString(Convert.FromBase64String(value));
    }

    public static string CreateHash(string password)
    {
        var modifiedPassword = password[..(password.Length / 2)].Reverse() + password[(password.Length / 2)..];

        using var md5 = MD5.Create();
        return Convert.ToHexString(md5.ComputeHash(Encoding.ASCII.GetBytes(modifiedPassword)));
    }

    public static IList<string> CheckPassword(string password)
    {
        var result = new List<string>();

        if (password.Length < PasswordConstants.MinPasswordLenght && password.Length > PasswordConstants.MaxPasswordLenght)
            result.Add("Password must be between 8 and 50 characters long.");

        if (ContainsDifferentCaseCharacters(password) is false)
            result.Add("Password must contain mixed-case characters.");

        if (ContainsNumbersOrSpecialCharacters(password) is false)
            result.Add("Password must contain numbers or special characters.");

        return result;
    }

    private static bool ContainsNumbersOrSpecialCharacters(string password)
        => password is not null && password.ToUpper().Except(password.ToLower()).Any() is true;

    private static bool ContainsDifferentCaseCharacters(string password)
        => password is not null && password.Except(password.ToLower()).Any() is true;
}