namespace Demo.Users.EntityFramework.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(p => p.Id)
            .IsRequired();

        builder
            .Property(p => p.Login)
            .IsRequired();

        builder
            .Property(p => p.FullName)
            .IsRequired();

        builder
            .Property(p => p.IsDeleted);

        builder.HasKey(e => e.Id);

        builder
            .HasIndex(e => e.Login)
            .IsUnique();
    }
}