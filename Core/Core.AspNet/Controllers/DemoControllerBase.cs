using Demo.Core.Domain.Exceptions;

namespace Demo.Core.AspNet.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class DemoControllerBase : ControllerBase
{
    protected async Task<IActionResult> ProcessRequestAsync<TResult>(Func<Task<TResult>> process, int notOkCode = StatusCodes.Status404NotFound)
    {
        try
        {
            var result = await process();

            if (result is null)
                return StatusCode(notOkCode);

            return StatusCode(StatusCodes.Status200OK, result);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (InvalidAuthDataException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.ProblemList);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status501NotImplemented, ex.Message);
        }
    }

    protected long? GetCurrentUserId()
    {
        var idString = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        if (long.TryParse(idString, out long id))
            return id;

        return null;
    }
}