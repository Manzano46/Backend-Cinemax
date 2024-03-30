namespace Cinemax.Contracts.Projections
{
    public record CreateProjectionRequest
    (
        string MovieId,
        string RoomId,
        DateTime Date,
        int Price
    );
}
