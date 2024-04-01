namespace Cinemax.Contracts.Users;

public record CreateUserRequest(
    string FirstName, 
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDay,
    string Role 
);