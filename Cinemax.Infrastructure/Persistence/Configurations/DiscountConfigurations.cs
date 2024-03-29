using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Discount.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class DiscountConfigurations : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        ConfigureDiscountsTable(builder);
    }

    private void ConfigureDiscountsTable(EntityTypeBuilder<Discount> builder){

        builder.ToTable("Discounts");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DiscountId.Create(value));
        builder.Property(m => m.Name)
            .HasMaxLength(100);
        
    }
}
