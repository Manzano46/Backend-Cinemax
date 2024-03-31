using Cinemax.Application.Rooms.Common;
using Cinemax.Application.RoomTypes.Commands.Create;
using Cinemax.Domain.RoomType.ValueObjects;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Create;
public record CreateRoomCommand(
    int Height,
    int Width,
    string Name,
    List<RoomTypeId> RoomTypesId
) : IRequest<RoomResult>;
