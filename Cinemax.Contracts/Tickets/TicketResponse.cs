using Cinemax.Contracts.Projections;
using Cinemax.Contracts.Seats;
using Cinemax.Contracts.Users;

namespace Cinemax.Contracts.Tickets
{
    public record TicketResponse
    (
        string Id,
        string SeatId,
        string UserId,
        string ProjectionId,
        DateTime Date,
        string TicketStatus,
        SeatResponseCore Seat,
        UserResponseCore User,
        ProjectionResponseCore Projection
    );

    public record TicketsResponse
    (
        List<TicketResponse> Tickets
    );
}