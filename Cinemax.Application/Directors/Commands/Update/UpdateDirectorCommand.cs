using Cinemax.Application.Directors.Common;
using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateDirectorCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<DirectorResult>;
