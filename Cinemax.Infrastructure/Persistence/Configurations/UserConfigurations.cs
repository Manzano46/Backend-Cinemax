using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder){
        builder.ToTable("Users");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        builder.Property(m => m.Email)
            .HasMaxLength(100);
        builder.Property(m => m.Password)
            .HasMaxLength(100);
        builder.Property(m => m.Points);
        builder.Property(m => m.BirthDay);
        builder.HasOne(m => m.Role);
        builder.HasMany(m => m.Cards)
                .WithMany(m => m.Users)
                .UsingEntity(m => m.ToTable("UserCards"));
    }
}
