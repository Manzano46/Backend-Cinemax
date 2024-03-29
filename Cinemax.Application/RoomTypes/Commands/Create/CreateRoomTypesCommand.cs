using Cinemax.Application.RoomTypes.Common;
using MediatR;

namespace Cinemax.Application.RoomTypes.Commands.Create;
public record CreateRoomTypeCommand(
    string Name
) : IRequest<RoomTypeResult>;
