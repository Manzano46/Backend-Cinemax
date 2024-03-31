namespace Cinemax.Contracts.Movies;

public record MovieResponse(
    string Id,
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL
);

public record MovieResponseCore(
    string Id,
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL
);