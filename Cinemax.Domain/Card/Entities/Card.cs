using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Domain.Card.Entities;
public class Card: Entity<CardId>{

    public virtual ICollection<User.Entities.User> Users { get; set; }
    #pragma warning disable CS8618
    private Card(){}
    #pragma warning restore CS8618
    
    private Card(CardId cardId,List<User.Entities.User> users = null!)
        : base(cardId){
            Users = users ?? [];
    }

    public static Card Create(CardId cardId,List<User.Entities.User> users = null!)
    {
        return new Card(cardId,users);
    }
}
