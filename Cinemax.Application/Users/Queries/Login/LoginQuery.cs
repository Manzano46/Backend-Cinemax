
using Cinemax.Application.Users.Common;
using MediatR;

namespace Cinemax.Application.Users.Queries.Login;
public record LoginQuery(
    string Email,
    string Password
) : IRequest<AuthenticationResult>;
