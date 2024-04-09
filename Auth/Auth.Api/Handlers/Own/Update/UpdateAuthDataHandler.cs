namespace Demo.Auth.Api.Handlers.Own.Update;

public class UpdateAuthDataHandler(AuthDbContext context) : IRequestHandler<UpdateAuthData, Unit>
{
    public async Task<Unit> Handle(UpdateAuthData request, CancellationToken ct)
    {
        var problemList = new List<string>();

        var target = await context.Set<AuthData>().FirstAsync(AuthData.FilterByLogin(request.CurrentLogin), ct);

        if (string.IsNullOrEmpty(request.NewLogin) is false)
            target.Login = request.NewLogin;

        if (string.IsNullOrEmpty(request.NewPassword) is false)
        {
            var password = PasswordHelper.StringFromBase64(request.NewPassword);
            if (string.IsNullOrEmpty(password))
                problemList.Add("Invalid Password");
            problemList = [.. PasswordHelper.CheckPassword(request.NewPassword)];

            if (problemList.Any())
                throw new InvalidAuthDataException(problemList);

            target.PasswordHash = PasswordHelper.CreateHash(password!);
        }

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}