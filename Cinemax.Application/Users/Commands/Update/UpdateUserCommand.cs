using Cinemax.Application.Users.Common;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Cinemax.Application.Users.Commands.Update
{
    public record UpdateUserCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<UserResult>;
}