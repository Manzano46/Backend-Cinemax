using Cinemax.Contracts.Movies;
namespace Cinemax.Contracts.Actors;

public record ActorResponse(
    string Id,
    string Firstname,
    string Lastname,
    List<CreateMovieRequest> Movies
);