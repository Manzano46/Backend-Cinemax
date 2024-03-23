namespace Cinemax.Contracts.Authentication;

public record AuthenticationResponse(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    DateOnly Birth,
    int Points,
    string Token 
);