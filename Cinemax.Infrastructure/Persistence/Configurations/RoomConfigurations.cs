using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class RoomConfigurations : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        ConfigureRoomsTable(builder);
    }

    private void ConfigureRoomsTable(EntityTypeBuilder<Room> builder){

        builder.ToTable("Rooms");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RoomId.Create(value));
        builder.Property(m => m.Height);
        builder.Property(m => m.Width);
        builder.HasMany(m => m.RoomTypes)
                .WithMany(m => m.Rooms)
                .UsingEntity(m => m.ToTable("RoomRoomType"));
    }
}
