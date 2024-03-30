using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.ValueObjects;
using MediatR;

namespace Cinemax.Application.Actors.Queries.Get;
public record GetActorQuery(
    ActorId ActorId
) : IRequest<ActorResult>;
