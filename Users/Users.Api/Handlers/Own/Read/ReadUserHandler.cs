namespace Demo.Users.Api.Handlers.Own.Read;

public class ReadUserHandler(UsersDbContext context) : IRequestHandler<ReadUser, UserResponse?>
{
    public async Task<UserResponse?> Handle(ReadUser request, CancellationToken ct)
    {
        if (request.IsValidRequest is false)
            throw new ArgumentException($"{nameof(request.Id)} XOR {nameof(request.Login)}");

        var filter = request.Id.HasValue ? User.FilterById(request.Id.Value) : User.FilterByLogin(request.Login!);

        var target = await context.Set<User>().FirstOrDefaultAsync(filter, ct);
        if (target is null)
            return null;

        return new UserResponse
        {
            Id = target.Id,
            Login = target.Login,
            FullName = target.FullName
        };
    }
}
