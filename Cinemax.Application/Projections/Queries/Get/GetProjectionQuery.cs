using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Projections.Queries.Get;
public record GetProjectionQuery(
    ProjectionId projectionId
) : IRequest<ProjectionResult>;
