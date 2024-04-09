using Microsoft.EntityFrameworkCore.Design;

namespace Demo.Core.EntityFramework.Factories;

public abstract class AbstractDesignTimeDbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    public TContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TContext>();
        // ...

        return (TContext)typeof(TContext).GetConstructor([optionsBuilder.Options.GetType()])!.Invoke([optionsBuilder.Options]);
    }
}