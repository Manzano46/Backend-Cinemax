using Cinemax.Application.Projections.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Projections.Commands.Create;
public record CreateProjectionCommand(
    MovieId MovieId,
    RoomId RoomId,
    DateTime Date,
    int Price
) : IRequest<ProjectionResult>;
