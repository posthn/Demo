namespace Demo.Users.Api.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddUsersServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<UsersDbContext>(options => options.UseInMemoryDatabase(connectionString));
        //...

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServicesExtension).Assembly));

        return services;
    }
}