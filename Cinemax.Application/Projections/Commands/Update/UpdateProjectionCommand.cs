using Cinemax.Application.Projections.Common;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateProjectionCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<ProjectionResult>;
