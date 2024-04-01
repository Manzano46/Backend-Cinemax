using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Card.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;

namespace Cinemax.Domain.Card.Entities;
public class Card: Entity<CardId>{

    public virtual ICollection<User.Entities.User> Users { get; set; }
    
    public virtual ICollection<Ticket> Tickets { get; set; }

    #pragma warning disable CS8618
    private Card(){}
    #pragma warning restore CS8618
    
    private Card(CardId cardId,List<User.Entities.User> users = null!, List<Ticket> tickets = null!)
        : base(cardId){
            Users = users ?? [];
            Tickets = tickets ?? [];
    }

    public static Card Create(CardId cardId,List<User.Entities.User> users = null!, List<Ticket> tickets = null!)
    {
        return new Card(cardId,users,tickets);
    }
}
