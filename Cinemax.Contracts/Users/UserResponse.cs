using Cinemax.Contracts.Movies;
using Cinemax.Contracts.Roles;
namespace Cinemax.Contracts.Users;

public record UserResponse(
    string Id,
    string Email,
    string Password,
    DateOnly BirthDay,
    string Name,
    int Points,
    CreateRoleRequest Role,
    List<CreateCardRequest> Cards
);

public record UserResponseCore(
    string Id,
    string Email,
    string Password,
    string Name,
    int Points
);
