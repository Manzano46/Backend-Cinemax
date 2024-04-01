using Cinemax.Contracts.Projections;
using Cinemax.Contracts.Seats;
using Cinemax.Contracts.Users;

namespace Cinemax.Contracts.Tickets
{
    public record TicketResponseCore
    (
        string Id,
        string SeatId,
        string UserId,
        string ProjectionId,
        DateTime Date,
        string TicketStatus
    );
}