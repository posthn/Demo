namespace Demo.Users.Api.Handlers.Own.Update;

public class UpdateUserHandler(UsersDbContext context, IMediator mediator) : IRequestHandler<UpdateUser, UserResponse?>
{
    public async Task<UserResponse?> Handle(UpdateUser request, CancellationToken ct)
    {
        if (request.HasValues is false)
            throw new ArgumentException("Invalid request");

        var target = await context.Set<User>().FirstOrDefaultAsync(User.FilterById(request.Context.UserId), ct);
        if (target is null)
            return null;

        var currentLogn = target.Login;

        if (string.IsNullOrEmpty(request.Login) is false)
        {
            var existing = await context.Set<User>().FirstOrDefaultAsync(User.FilterByLogin(request.Login), ct);
            if (existing is not null)
                throw new ArgumentException($"Login: {request.Login} is busy");

            target.Login = request.Login;
        }

        if (string.IsNullOrEmpty(request.Fullname) is false)
            target.FullName = request.Fullname;

        if (string.IsNullOrEmpty(request.Login) is false || string.IsNullOrEmpty(request.Password) is false)
            await mediator.Send(new UpdateAuthData
            {
                CurrentLogin = currentLogn,
                NewLogin = request.Login,
                NewPassword = request.Password
            }, ct);

        await context.SaveChangesAsync(ct);

        return new UserResponse
        {
            Id = target.Id,
            Login = target.Login,
            FullName = target.FullName
        };
    }
}