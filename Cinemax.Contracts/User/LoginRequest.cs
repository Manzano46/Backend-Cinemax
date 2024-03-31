namespace Cinemax.Contracts.Users;

public record LoginRequest(
    string Email,
    string Password 
);