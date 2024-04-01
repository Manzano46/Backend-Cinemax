using Cinemax.Application.Movies.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Movies.Queries.Get;
public record GetMovieByNameQuery(
    string MovieName
) : IRequest<MovieResult>;
