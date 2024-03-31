using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Rooms.Queries.Get;
public record GetRoomQuery(
    RoomId RoomId
) : IRequest<RoomResult>;
