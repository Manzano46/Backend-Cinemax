using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinemax.Infrastructure.Persistence.Configurations;
public class CardConfigurations : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        ConfigureCardsTable(builder);
    }

    private void ConfigureCardsTable(EntityTypeBuilder<Card> builder){
        builder.ToTable("Cards");
        builder.HasKey(m => m.Number);
        builder.Property(m => m.Number)
            .ValueGeneratedNever()
            .HasConversion(
                number => number.Value,
                value => CardNumber.Create(value));        
    }
}
