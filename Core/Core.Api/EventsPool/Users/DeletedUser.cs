namespace Demo.Core.Api.EventsPool.Users;

public class DeletedUser : INotification
{
    public long Id { get; set; }

    public string Login { get; set; }
}