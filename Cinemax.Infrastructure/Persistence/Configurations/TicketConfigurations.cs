using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Role.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Cinemax.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class TicketConfigurations : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        ConfigureTicketsTable(builder);
    }

    private void ConfigureTicketsTable(EntityTypeBuilder<Ticket> builder){
        builder.ToTable("Tickets");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => TicketId.Create(value));

        builder.Property(m => m.SeatId)
            .HasConversion(
                id => id.Value,
                value => SeatId.Create(value));

        builder.Property(m => m.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(m => m.ProjectionId)
            .HasConversion(
                id => id.Value,
                value => ProjectionId.Create(value));
        
        builder.Property(m => m.Date);
        
        builder.Property(m => m.TicketStatus)
            .HasConversion(
                status => status.ToString(),
                status => Enum.Parse<TicketStatus>(status));

        builder.HasOne(m => m.Seat)
            .WithMany(s=>s.Tickets)
            .HasForeignKey(m=>m.SeatId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Projection)
            .WithMany(u => u.Tickets)
            .HasForeignKey(m=>m.ProjectionId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(m => m.User)
            .WithMany(u=>u.Tickets)
            .HasForeignKey(m=>m.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
