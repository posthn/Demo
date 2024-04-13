namespace Demo.Auth.Api.Handlers.Own.Update;

public class UpdateAuthDataHandler(AuthDbContext context) : IRequestHandler<UpdateAuthData, Unit>
{
    public async Task<Unit> Handle(UpdateAuthData request, CancellationToken ct)
    {
        var target = await context.Set<AuthData>().FirstAsync(AuthData.FilterByLogin(request.CurrentLogin), ct);

        if (string.IsNullOrEmpty(request.NewLogin) is false)
            target.Login = request.NewLogin;

        if (string.IsNullOrEmpty(request.NewPassword) is false)
        {
            var problemList = PasswordHelper.CheckPassword(request.NewPassword);
            if (problemList.Any())
                throw new InvalidAuthDataException(problemList);

            var password = PasswordHelper.GetStringFromBase64(request.NewPassword);
            target.PasswordHash = PasswordHelper.CreateHash(password);
        }

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}