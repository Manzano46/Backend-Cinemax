namespace Cinemax.Contracts.Movies;

public record CreateMovieRequest(
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL
);