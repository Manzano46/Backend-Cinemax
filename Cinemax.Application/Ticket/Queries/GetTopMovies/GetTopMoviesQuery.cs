using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Infrastructure.Services.Statistics;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetTopMovies;
public record GetTopMoviesQuery(
    DateTime StartDate,
    DateTime EndDate,
    int Top
) : IRequest<IEnumerable<TopMovie>>;
