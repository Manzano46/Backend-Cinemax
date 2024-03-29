using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class DirectorConfigurations : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        ConfigureDirectorsTable(builder);
    }

    private void ConfigureDirectorsTable(EntityTypeBuilder<Director> builder){

        builder.ToTable("Directors");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DirectorId.Create(value));
        builder.Property(m => m.FirstName)
            .HasMaxLength(100);
        builder.Property(m => m.LastName)
            .HasMaxLength(100);
        
    }
}
