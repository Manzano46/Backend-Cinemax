using Cinemax.Domain.User;

namespace Cinemax.Application.Authentication.Common;
public record AuthenticationResult(
    User User, string Token
);