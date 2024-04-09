namespace Demo.Executable.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddDemoServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region BaseServices
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    }
                );

                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        }
                    }
                );
            });

        services.AddCors(options => options.AddPolicy("AllowAll", policyBuilder =>
            policyBuilder
                .SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            )
        );
        #endregion

        services.AddAuthServices(/* configuration["AuthConnectionString"] */"AuthDb", configuration["JwtKey"]);
        services.AddUsersServices(/* configuration["UsersConnectionString"] */"UsersDb");

        return services;
    }
}