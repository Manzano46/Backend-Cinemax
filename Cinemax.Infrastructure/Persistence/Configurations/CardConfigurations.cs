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
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                Id => Id.Value,
                value => CardId.Create(value));        
    }
}
