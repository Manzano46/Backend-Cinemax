using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.Entities;
using Cinemax.Domain.Seat.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class SeatConfigurations : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        ConfigureSeatsTable(builder);
    }

    private void ConfigureSeatsTable(EntityTypeBuilder<Seat> builder){

        builder.ToTable("Seats");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => SeatId.Create(value));

        builder.Property(m => m.RoomId)
            .HasConversion(
                id => id.Value,
                value => RoomId.Create(value));

        builder.HasOne(m => m.Room)
            .WithMany(m => m.Seats)
            .HasForeignKey(m => m.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
