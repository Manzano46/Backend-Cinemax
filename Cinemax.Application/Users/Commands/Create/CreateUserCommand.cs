using Cinemax.Application.Users.Common;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Application.Movies.Commands.Create;
using MediatR;
using Cinemax.Application.Roles.Commands.Create;

namespace Cinemax.Application.Users.Commands.Create;
public record CreateUserCommand(
    string Email,
    string Password,
    DateOnly BirthDay,
    string Name,
    int Points,
    CreateRoleCommand Role,
    List<CreateCardCommand> Cards
) : IRequest<UserResult>;

