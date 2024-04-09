namespace Demo.Executable.Extensions;

public static class WebApplicationExtension
{
    public static WebApplication UseDemoMiddleware(this WebApplication app)
    {
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}