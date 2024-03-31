using MediatR;
using Cinemax.Application.Roles.Commands.Create;
using Cinemax.Application.Cards.Commands.Create;
using Cinemax.Application.Users.Common;

namespace Cinemax.Application.Users.Commands.Create;
public record CreateUserCommand(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateOnly BirthDay,
    int Points,
    CreateRoleCommand Role,
    List<CreateCardCommand> Cards
) : IRequest<AuthenticationResult>;

