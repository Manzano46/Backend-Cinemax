using Cinemax.Application.Roles.Common;
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateRoleCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<RoleResult>;
