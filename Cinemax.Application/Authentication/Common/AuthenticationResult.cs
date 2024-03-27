using Cinemax.Domain.User.Entities;

namespace Cinemax.Application.Authentication.Common;
public record AuthenticationResult(
    User User, string Token
);