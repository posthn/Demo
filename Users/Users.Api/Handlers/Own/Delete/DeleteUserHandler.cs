namespace Demo.Users.Api.Handlers.Own.Delete;

public class DeleteUserHandler(UsersDbContext context, IMediator mediator) : IRequestHandler<DeleteUser, Unit>
{
    public async Task<Unit> Handle(DeleteUser request, CancellationToken ct)
    {
        var target = await context.Set<User>().FirstOrDefaultAsync(User.FilterById(request.Context.UserId), ct);
        if (target is null)
            return Unit.Value;

        if (request.WithoutSaving is false)
        {
            if (target.IsDeleted is false)
                target.SwithDeleteFlag();

            return Unit.Value;
        }

        context.Remove(target);

        await mediator.Publish(new DeletedUser
        {
            Id = target.Id,
            Login = target.Login
        }, ct);

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}