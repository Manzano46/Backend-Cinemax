using Cinemax.Application.Roles.Common;
using Cinemax.Domain.Role.ValueObjects;
using MediatR;

namespace Cinemax.Application.Roles.Commands.Create;
public record CreateRoleCommand(
    string Name
) : IRequest<RoleResult>;

