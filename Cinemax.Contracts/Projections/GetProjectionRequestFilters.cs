namespace Cinemax.Contracts.Projections
{
    public record GetProjectionRequestFilters
    (
        DateTime DateInit,
        DateTime DateEnd,
        float MinPrice,
        float MaxPrice
    );
}
