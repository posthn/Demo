namespace Demo.Auth.Api.Handlers.Own.Create;

public class CreateAuthDataHandler(AuthDbContext context) : IRequestHandler<CreateAuthData, Unit>
{
    public async Task<Unit> Handle(CreateAuthData request, CancellationToken ct)
    {
        var problemList = PasswordHelper.CheckPassword(request.Password);

        if (problemList.Any())
            throw new InvalidAuthDataException(problemList);

        var password = PasswordHelper.GetStringFromBase64(request.Password);
        await context.AddAsync(new AuthData(request.Login, PasswordHelper.CreateHash(password)), ct);

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}