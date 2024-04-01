using Cinemax.Domain.Common.Models;
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
    paid
}
public class Ticket : Entity<TicketId>{
    public SeatId SeatId {get; set;}
    public virtual Seat.Entities.Seat Seat {get; set;}

    public UserId UserId {get; set;}
    public virtual User.Entities.User User {get; set;}

    public ProjectionId ProjectionId {get; set;}
    public virtual Projection Projection {get; set;}

    public DateTime Date {get; set;}
    public TicketStatus TicketStatus {get; set;}    

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
    
    public static Ticket Create(SeatId seatId, UserId userId, ProjectionId projectionId, DateTime date, TicketStatus ticketStatus, Seat.Entities.Seat seat = null!, User.Entities.User user = null!, Projection projection = null!){

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
