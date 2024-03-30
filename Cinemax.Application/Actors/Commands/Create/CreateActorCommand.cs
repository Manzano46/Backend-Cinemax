using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.ValueObjects;
using Cinemax.Application.Movies.Commands.Create;
using MediatR;

namespace Cinemax.Application.Actors.Commands.Create;
public record CreateActorCommand(
    string Firstname,
    string Lastname,
    List<CreateMovieCommand> Movies
) : IRequest<ActorResult>;

