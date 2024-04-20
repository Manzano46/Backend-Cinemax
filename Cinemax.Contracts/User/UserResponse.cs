using Cinemax.Contracts.Cards;
using Cinemax.Contracts.Movies;
using Cinemax.Contracts.Roles;
namespace Cinemax.Contracts.Users;

public record UserResponse(
    string Id,
    string FirstName, 
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDay,
    int Points,
    RoleResponse Role,
    List<CardResponse> Cards
);

public record UserResponseCore(
    string Id,
    string FirstName, 
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDay,
    int Points
);

public record AuthenticationResponse(
    string Id,
    string FirstName, 
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDay,
    int Points,
    RoleResponse Role,
    List<CardResponse> Cards,
    string Token
);

public record AuthenticationResponseCore(
    string Id,
    string FirstName, 
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDay,
    int Points,
    string Token
);