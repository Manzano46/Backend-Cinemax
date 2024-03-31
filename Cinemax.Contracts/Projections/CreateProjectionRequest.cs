namespace Cinemax.Contracts.Projections
{
    public record CreateProjectionRequest
    (
        string Movie,
        string Room,
        DateTime Date,
        int Price
    );
}
