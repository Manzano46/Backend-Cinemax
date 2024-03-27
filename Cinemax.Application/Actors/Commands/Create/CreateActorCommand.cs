using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.ValueObjects;
using MediatR;

namespace Cinemax.Application.Actors.Commands.Create;
public record CreateActorCommand(
    string Firstname,
    string Lastname
) : IRequest<ActorResult>;

