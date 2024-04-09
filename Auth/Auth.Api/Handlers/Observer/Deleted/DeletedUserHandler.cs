namespace Demo.Auth.Api.Handlers.Observer;

public class DeletedUserNotificationHandler(AuthDbContext context) : INotificationHandler<DeletedUser>
{
    public async Task Handle(DeletedUser notification, CancellationToken ct)
    {
        var target = await context.Set<AuthData>().FirstAsync(AuthData.FilterByLogin(notification.Login), ct);

        context.Remove(target);

        await context.SaveChangesAsync(ct);
    }
}