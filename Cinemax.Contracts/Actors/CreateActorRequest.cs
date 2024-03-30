using Cinemax.Contracts.Movies;
namespace Cinemax.Contracts.Actors
{
    public record CreateActorRequest(
        string Firstname,
        string Lastname
    );
}
