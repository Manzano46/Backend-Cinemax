namespace Cinemax.Contracts.Seats
{
    public record CreateSeatRequest
    (
        string Room,
        int Row,
        int Column
    );
}
