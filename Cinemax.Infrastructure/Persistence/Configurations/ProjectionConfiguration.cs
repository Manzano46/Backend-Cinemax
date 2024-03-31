using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations
{
    public class ProjectionConfiguration : IEntityTypeConfiguration<Projection>
    {

        public void Configure(EntityTypeBuilder<Projection> builder)
        {
            ConfigureProjectionsTable(builder);
        }

        private void ConfigureProjectionsTable(EntityTypeBuilder<Projection> builder)
        {

            builder.ToTable("Projections");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                 id => id.Value,
                 value => ProjectionId.Create(value));
            
            builder.Property(m => m.MovieId)
                .HasConversion(
                id => id.Value,
                value => MovieId.Create(value));
            
            builder.Property(m => m.RoomId)
                .HasConversion(
                id => id.Value,
                value => RoomId.Create(value));

            builder.Property(m => m.Date);
            builder.Property(m => m.Price);

            builder.HasOne(m => m.Movie)
                .WithMany()
                .HasForeignKey(m => m.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.Room)
                .WithMany()
                .HasForeignKey(m => m.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
