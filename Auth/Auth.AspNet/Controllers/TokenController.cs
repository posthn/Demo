namespace Demo.Auth.AspNet.Controllers;

public class AuthController(IMediator mediator) : DemoControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateToken(CreateToken request, CancellationToken ct)
        => await ProcessRequestAsync(() => mediator.Send(request, ct));
}