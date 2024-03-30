using Cinemax.Application.RoomTypes.Common;
using Cinemax.Domain.RoomType.ValueObjects;
using MediatR;

namespace Cinemax.Application.RoomTypes.Queries.Get;
public record GetRoomTypeQuery(
    RoomTypeId RoomTypeId
) : IRequest<RoomTypeResult>;
