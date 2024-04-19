namespace Demo.Auth.Api.Extensions;

public static class ServiceProdviderExtension
{
    public static void ApplyAuthMigrations(this IServiceProvider provider)
        => provider.GetRequiredService<AuthDbContext>().Database.Migrate();
}