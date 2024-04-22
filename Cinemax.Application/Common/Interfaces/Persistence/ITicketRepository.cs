using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Infrastructure.Services.Statistics;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface ITicketRepository: IRepository<Ticket, TicketId>{
    Ticket? GetTicketByKeys(SeatId seatId, UserId userId, ProjectionId projectionId, TicketStatus ticketStatus);
    Ticket? GetTicketByKeysNoUser(SeatId seatId, ProjectionId projectionId, TicketStatus ticketStatus);
    IEnumerable<Ticket>? GetTicketByProjection(ProjectionId projectionId);
    IEnumerable<Ticket>? GetTicketsReserved();
    IEnumerable<Ticket>? GetTicketsReservedByUser(UserId userId);
    Task<List<RoomTicketCount>>? GetTopRoomCountsAsync(DateTime startDate, DateTime endDate,int limit);
    Task<List<TopMovie>>? GetTopMoviesAsync(DateTime startDate, DateTime endDate,int limit);
    Task<List<SectionTicketCount>> GetSectionTicketCountsAsync();
}