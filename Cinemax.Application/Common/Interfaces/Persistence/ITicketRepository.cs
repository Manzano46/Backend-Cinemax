using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Cinemax.Domain.User.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface ITicketRepository{
    Ticket? GetById(TicketId TicketId);
    Ticket? GetTicketByKeys(SeatId seatId, UserId userId, ProjectionId projectionId, TicketStatus ticketStatus);
    Ticket? GetTicketByKeysNoUser(SeatId seatId, ProjectionId projectionId, TicketStatus ticketStatus);
    IEnumerable<Ticket>? GetTicketByProjection(ProjectionId projectionId);
    IEnumerable<Ticket>? GetTicketsReserved();
    IEnumerable<Ticket>? GetTicketsReservedByUser(UserId userId);
    void Add(Ticket Ticket);
    void Delete(TicketId TicketId);
    IEnumerable<Ticket> GetAll();
}