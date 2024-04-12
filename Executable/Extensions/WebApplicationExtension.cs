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

        return app;
    }
}