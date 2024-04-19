namespace Demo.Users.Api.Extensions;

public static class ServiceProdviderExtension
{
    public static void ApplyUsersMigrations(this IServiceProvider provider)
        => provider.GetRequiredService<UsersDbContext>().Database.Migrate();
}