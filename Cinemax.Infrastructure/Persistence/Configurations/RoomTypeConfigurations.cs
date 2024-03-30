using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.RoomType.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class RoomTypeConfigurations : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        ConfigureRoomTypesTable(builder);
    }

    private void ConfigureRoomTypesTable(EntityTypeBuilder<RoomType> builder){

        builder.ToTable("RoomTypes");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RoomTypeId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        
    }
}
