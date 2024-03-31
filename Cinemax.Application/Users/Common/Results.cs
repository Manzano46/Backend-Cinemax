using Cinemax.Domain.User.Entities;

namespace Cinemax.Application.Users.Common;
public record AuthenticationResult(
    User User,string Token
);

public record UserResult(
    User User
);