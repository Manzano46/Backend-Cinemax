using Cinemax.Domain.Entities;

namespace Cinemax.Application.Authentication.Common;
public record AuthenticationResult(
    User User, string Token
);