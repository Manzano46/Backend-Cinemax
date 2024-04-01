namespace Cinemax.Contracts.Users;

public record RegisterRequest(
    string FirstName, 
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDay 
);