using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        ConfigureRolesTable(builder);
    }

    private void ConfigureRolesTable(EntityTypeBuilder<Role> builder){

        builder.ToTable("Roles");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RoleId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        
    }
}
