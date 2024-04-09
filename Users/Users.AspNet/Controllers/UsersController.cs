namespace Demo.Users.AspNet.Controllers;

public class UsersController(IMediator mediator) : DemoControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserBody request, CancellationToken ct)
        => await ProcessRequestAsync(() => mediator.Send(new CreateUser
        {
            Login = request.Login,
            Password = request.Password,
            FullName = request.FullName
        }, ct));

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken ct)
        => await ProcessRequestAsync(() => mediator.Send(new ReadUser { Id = GetCurrentUserId()!.Value }, ct));

    [Authorize]
    [HttpGet("/list/")]
    public async Task<IActionResult> ReadUserListAsync([FromBody] ReadUserListBody request, CancellationToken ct)
        => await ProcessRequestAsync(() => mediator.Send(new ReadUserList
        {
            FilterSubstring = request.SubstringFilter,
            Context = { Pager = request.Pager }
        }, ct));

    [Authorize]
    [HttpPatch]
    public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserBody request, CancellationToken ct)
        => await ProcessRequestAsync(() => mediator.Send(new UpdateUser
        {
            Login = request.Login,
            Password = request.Password,
            Fullname = request.Fullname,
            Context = { UserId = GetCurrentUserId()!.Value }
        }, ct));

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteUserAsync(bool withoutSaving, CancellationToken ct)
        => await ProcessRequestAsync(() => mediator.Send(new DeleteUser
        {
            WithoutSaving = withoutSaving,
            Context = { UserId = GetCurrentUserId()!.Value }
        }, ct));
}