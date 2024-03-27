using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.Genre.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class GenreConfigurations : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        ConfigureGenresTable(builder);
    }

    private void ConfigureGenresTable(EntityTypeBuilder<Genre> builder){

        builder.ToTable("Genres");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GenreId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
    }
}
