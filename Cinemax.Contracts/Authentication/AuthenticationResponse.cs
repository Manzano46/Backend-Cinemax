namespace Cinemax.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateOnly Birth,
    int Points,
    string Token 
);