using Demo.Core.Api.RequestsPool.Users.Read;

namespace Demo.Auth.Api.Handlers.Own.Create;

public class CreateTokenHandler(IMediator mediator, AuthDbContext context, TokenManager manager) : IRequestHandler<CreateToken, TokenResponse?>
{
    public async Task<TokenResponse?> Handle(CreateToken request, CancellationToken ct)
    {
        if (string.IsNullOrEmpty(request.Login) || string.IsNullOrEmpty(request.Password))
            return null;

        var target = await context.Set<AuthData>().FirstOrDefaultAsync(AuthData.FilterByLogin(request.Login), ct);
        if (target is null)
            return null;

        var password = PasswordHelper.GetStringFromBase64(request.Password);
        if (string.Compare(PasswordHelper.CreateHash(password), target.PasswordHash) != 0)
            return null;

        var user = await mediator.Send(new ReadUser { Login = target.Login }, ct);
        if (user is null)
            return null;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(manager.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, user.Id.ToString()) };

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddHours(24), signingCredentials: credentials);

        return new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
}