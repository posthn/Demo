namespace Demo.Users.Api.Handlers.Own.Create;

public class CreateUserHandler(UsersDbContext context, IMediator mediator) : IRequestHandler<CreateUser, UserResponse?>
{
    public async Task<UserResponse?> Handle(CreateUser request, CancellationToken ct)
    {
        var existing = await context.Set<User>().FirstOrDefaultAsync(User.FilterByLogin(request.Login), ct);
        if (existing is not null)
            throw new ArgumentException($"Login: {request.Login} is busy");

        await mediator.Send(new CreateAuthData
        {
            Login = request.Login,
            Password = request.Password
        });

        var @new = new User(request.Login, request.FullName);
        await context.Set<User>().AddAsync(@new, ct);
        await context.SaveChangesAsync(ct);

        return new UserResponse
        {
            Id = @new.Id,
            Login = @new.Login
        };
    }
}
