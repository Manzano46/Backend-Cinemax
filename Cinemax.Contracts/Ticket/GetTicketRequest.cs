namespace Cinemax.Contracts.Ticket
{
    public record GetTicketRequest
    (
        string room,
        string seat,
        string date,
        string time,
        string id,
        string movie,
        string price
        );
}
