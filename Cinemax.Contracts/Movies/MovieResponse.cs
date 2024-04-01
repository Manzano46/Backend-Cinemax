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
    string Summary,
    string CoverURL,
    string ImagenURL,
    List<ActorResponseCore> Actors,
    List<CountryResponseCore> Countries,
    List<DirectorResponseCore> Directors,
    List<GenreResponseCore> Genres
);

public record MovieResponseCore(
    string Id,
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL,
    string Summary,
    string CoverURL,
    string ImagenURL
);
