using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Domain.Card.Entities;
public class Card: Entity<CardNumber>{
    public CardNumber Number {get;set;}

    #pragma warning disable CS8618
    private Card(){}
    #pragma warning restore CS8618
    private Card(CardNumber cardNumber)
        : base(cardNumber){
            Number=cardNumber;
    }

    public static Card Create(CardNumber cardNumber)
    {
        return new Card(cardNumber);
    }
}
