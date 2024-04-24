using Cinemax.Domain.Card.ValueObjects;
using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Discount.ValueObjects;
using Cinemax.Domain.PaymentType.ValueObjects;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Cinemax.Domain.User.ValueObjects;

namespace Cinemax.Domain.TicketAggregate.Entities;

public enum TicketStatus
{
    available,
    reserved,
    paid,
    expired
}
public class Ticket : Entity<TicketId>{
    public SeatId SeatId {get; set;}
    public virtual Seat.Entities.Seat Seat {get; set;}

    public UserId UserId {get; set;}
    public virtual User.Entities.User User {get; set;}

    public ProjectionId ProjectionId {get; set;}
    public virtual Projection Projection {get; set;}
    public CardId CardId {get; set;} = null!;
    public virtual Card.Entities.Card? Card {get; set;}
    public PaymentTypeId PaymentTypeId {get; set;} = null!;
    public virtual PaymentType.Entities.PaymentType? PaymentType {get; set;}
    public DateTime Date {get; set;}
    public TicketStatus TicketStatus {get; set;}    
    public virtual ICollection<Discount.Entities.Discount> Discounts {get; set;} = null!;
    #pragma warning disable CS8618
    private Ticket(){}
    #pragma warning restore CS8618

    private Ticket(TicketId ticketId, SeatId seatId, UserId userId, ProjectionId projectionId, DateTime date, TicketStatus ticketStatus, Seat.Entities.Seat seat = null!, User.Entities.User user = null!, Projection projection = null!)
        : base(ticketId){
            SeatId = seatId;
            UserId = userId;
            ProjectionId = projectionId;
            Date = date;
            TicketStatus = ticketStatus;
            Seat = seat;
            User = user;
            Projection = projection;
    }
    
    public static Ticket Create(SeatId seatId, UserId userId, ProjectionId projectionId, DateTime date,TicketStatus ticketStatus, Seat.Entities.Seat seat = null!, User.Entities.User user = null!, Projection projection = null!){

            return new(TicketId.CreateUnique() ,
                        seatId,
                        userId,
                        projectionId,
                        date,
                        ticketStatus,
                        seat,
                        user,
                        projection
                        
           );

    }

}


public record SectionTicketCount
{
    public string SectionName { get; init; } = "";
    public int TicketCount { get; init; }
    public int Sales { get; init; }
}