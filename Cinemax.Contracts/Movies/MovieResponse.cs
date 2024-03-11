namespace Cinemax.Contracts.Movies;

public record MovieResponse(
    Guid Id,
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL
);