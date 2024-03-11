using Cinemax.Application.Authentication.Common;
using MediatR;

namespace Cinemax.Application.Authentication.Commands.Register;
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime Birth
) : IRequest<AuthenticationResult>;
