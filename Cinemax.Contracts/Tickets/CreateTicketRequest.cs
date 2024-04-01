namespace Cinemax.Contracts.Tickets
{
    public record CreateTicketRequest
    (
        string SeatId,
        string UserId,
        string ProjectionId
    );
}
