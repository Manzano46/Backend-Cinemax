using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Projections.Commands.Delete;
public record DeleteProjectionCommand(
    ProjectionId Id
) : IRequest<ProjectionResult>;
