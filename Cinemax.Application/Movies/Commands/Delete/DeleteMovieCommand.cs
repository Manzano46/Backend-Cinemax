using Cinemax.Application.Movies.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Movies.Commands.Delete;
public record DeleteMovieCommand(
    MovieId MovieId
) : IRequest<MovieResult>;
