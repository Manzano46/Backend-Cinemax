using Cinemax.Application.Roles.Common;
using Cinemax.Domain.Role.ValueObjects;
using MediatR;

public record DeleteRoleCommand(RoleId Id) : IRequest<RoleResult>;
