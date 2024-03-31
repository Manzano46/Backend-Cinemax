using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Domain.Card.Entities;
public class Card: Entity<CardId>{

    #pragma warning disable CS8618
    private Card(){}
    #pragma warning restore CS8618
    
    private Card(CardId cardId)
        : base(cardId){
    }

    public static Card Create(CardId cardId)
    {
        return new Card(cardId);
    }
}
