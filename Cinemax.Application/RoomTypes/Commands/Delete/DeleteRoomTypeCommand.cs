using Cinemax.Application.RoomTypes.Common;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.RoomType.ValueObjects;
using MediatR;

namespace Cinemax.Application.RoomTypes.Commands.Delete;
public record DeleteRoomTypeCommand(
    RoomTypeId Id
) : IRequest<RoomTypeResult>;
