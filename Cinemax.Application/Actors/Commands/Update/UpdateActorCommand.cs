using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateActorCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<ActorResult>;
