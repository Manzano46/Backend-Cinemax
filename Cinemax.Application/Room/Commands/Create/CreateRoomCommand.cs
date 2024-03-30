using Cinemax.Application.Rooms.Common;
using Cinemax.Application.RoomTypes.Commands.Create;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Create;
public record CreateRoomCommand(
    int Height,
    int Width,
    List<CreateRoomTypeCommand> RoomTypes
) : IRequest<RoomResult>;
