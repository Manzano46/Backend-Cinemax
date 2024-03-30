using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class ActorConfigurations : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        ConfigureActorsTable(builder);
    }

    private void ConfigureActorsTable(EntityTypeBuilder<Actor> builder){

        builder.ToTable("Actors");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ActorId.Create(value));
        builder.Property(m => m.FirstName)
            .HasMaxLength(100);
        builder.Property(m => m.LastName)
            .HasMaxLength(100);
        builder.HasMany(m => m.Movies)
                .WithMany(m => m.Actors)
                .UsingEntity(m => m.ToTable("ActorMovies"));
        
    }
}
