using Cinemax.Contracts.Actors;
using Cinemax.Contracts.Countries;
using Cinemax.Contracts.Directors;
using Cinemax.Contracts.Genres;

namespace Cinemax.Contracts.Movies;

public record MovieResponse(
    string Id,
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL,
    List<ActorResponse> Actors,
    List<CountryResponse> Countries,
    List<DirectorResponse> Directors,
    List<GenreResponse> Genres
);