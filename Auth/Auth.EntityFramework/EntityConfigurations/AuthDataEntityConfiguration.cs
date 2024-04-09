namespace Demo.Auth.EntityFramework.EntityConfigurations;

public class AuthDataEntityConfiguration : IEntityTypeConfiguration<AuthData>
{
    public void Configure(EntityTypeBuilder<AuthData> builder)
    {
        builder
            .Property(x => x.Login)
            .IsRequired();

        builder
            .Property(x => x.PasswordHash)
            .IsRequired();

        builder
            .HasKey(x => x.Login);
    }
}