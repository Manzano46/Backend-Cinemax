namespace Cinemax.Contracts.Tickets
{
    public record ConfirmTicketsRequest
    (
        List<ConfirmTicketRequest> ConfirmTicketsRequests
    );
}
