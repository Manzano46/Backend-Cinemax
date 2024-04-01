namespace Cinemax.Contracts.Tickets
{
    public record ConfirmTicketRequest
    (
        string SeatId,
        string UserId,
        string ProjectionId
    );
}
