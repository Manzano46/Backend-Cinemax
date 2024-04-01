namespace Cinemax.Contracts.Tickets
{
    public record CreateTicketsRequest
    (
        List<CreateTicketRequest> CreateTicketsRequests
    );
}
