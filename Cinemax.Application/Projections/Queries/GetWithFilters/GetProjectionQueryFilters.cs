using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Get;
public record GetProjectionQueryFilters(
    DateTime DateInit,
    DateTime DateEnd,
    float MinPrice,
    float MaxPrice
) : IRequest<List<ProjectionResult>>;
