namespace Demo.Executable.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication UseDemoMiddleware(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("AllowAll");

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        if (app.Environment.IsDevelopment())
        {
            var provider = app.Services.CreateScope().ServiceProvider;

            provider.ApplyAuthMigrations();
            provider.ApplyUsersMigrations();
        }

        return app;
    }
}