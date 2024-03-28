using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class CountryConfigurations : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        ConfigureCountriesTable(builder);
    }

    private void ConfigureCountriesTable(EntityTypeBuilder<Country> builder){

        builder.ToTable("Countries");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CountryId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        
    }
}
