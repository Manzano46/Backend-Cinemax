using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.ValueObjects;
using MediatR;

public record DeleteActorCommand(ActorId Id) : IRequest<ActorResult>;
