namespace Cinemax.Contracts.Directors;

public record DirectorResponse(
    string Id,
    string Firstname,
    string Lastname
);

public record DirectorResponseCore(
    string Id,
    string Firstname,
    string Lastname
);