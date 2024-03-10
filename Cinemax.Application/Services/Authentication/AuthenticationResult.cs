using Cinemax.Domain.Entities;

namespace Cinemax.Application.Services.Authentication;
public record AuthenticationResult(
    User User,
    string Token
);