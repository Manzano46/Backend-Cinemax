
using Cinemax.Application.Authentication.Common;
using MediatR;

namespace Cinemax.Application.Authentication.Queries.Login;
public record LoginQuery(
    string Email,
    string Password
) : IRequest<AuthenticationResult>;
