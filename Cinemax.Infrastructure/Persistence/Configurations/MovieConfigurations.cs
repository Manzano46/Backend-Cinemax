using Cinemax.Domain.MovieAggregate.Entities;
using Cinemax.Domain.MovieAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class MovieConfigurations : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        ConfigureMoviesTable(builder);
    }

    private void ConfigureMoviesTable(EntityTypeBuilder<Movie> builder){

        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MovieId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        builder.Property(m => m.Description)
            .HasMaxLength(100);
        builder.Property(m => m.Duration);
        builder.Property(m => m.Premiere);
        builder.Property(m => m.IconURL)
            .HasMaxLength(100);
        builder.Property(m => m.TrailerURL)
            .HasMaxLength(100);
        
    }
}
