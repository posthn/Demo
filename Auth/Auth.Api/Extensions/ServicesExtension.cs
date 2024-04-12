namespace Demo.Auth.Api.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services, string connectionString, string key)
    {
        services.AddDbContext<AuthDbContext>(options => options.UseNpgsql(connectionString));
        services.AddTransient(_ => new TokenManager(key));

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServicesExtension).Assembly));

        return services;
    }
}