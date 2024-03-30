using Cinemax.Application.RoomTypes.Common;
using MediatR;

namespace Cinemax.Application.RoomTypes.Commands.Delete;
public record DeleteRoomTypeCommand(
    string Name
) : IRequest<RoomTypeResult>;
