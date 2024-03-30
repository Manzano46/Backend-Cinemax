using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.Room.ValueObjects;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Delete;
public record DeleteRoomCommand(
    RoomId Id
) : IRequest<RoomResult>;
