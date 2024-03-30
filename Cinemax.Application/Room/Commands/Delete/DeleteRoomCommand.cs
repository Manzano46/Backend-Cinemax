using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Delete;
public record DeleteProjectionCommand(
    RoomId Id
) : IRequest<RoomResult>;
