using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class PaymentTypeConfigurations : IEntityTypeConfiguration<PaymentType>
{
    public void Configure(EntityTypeBuilder<PaymentType> builder)
    {
        ConfigurePaymentTypesTable(builder);
    }

    private void ConfigurePaymentTypesTable(EntityTypeBuilder<PaymentType> builder){

        builder.ToTable("PaymentTypes");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PaymentTypeId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        
        builder.HasMany(m => m.Tickets)
            .WithOne(t => t.PaymentType)
            .HasForeignKey(t => t.PaymentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
