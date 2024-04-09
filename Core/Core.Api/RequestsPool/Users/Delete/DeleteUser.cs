namespace Demo.Core.Api.RequestsPool.Users.Delete;

public class DeleteUser : RequestBase<Unit>
{
    public bool WithoutSaving { get; set; } = false;
}