using Cinemax.Contracts.Movies;
namespace Cinemax.Contracts.Users
{
    public record CreateUserRequest(
        string Email,
        string Password,
        string Name);
}
