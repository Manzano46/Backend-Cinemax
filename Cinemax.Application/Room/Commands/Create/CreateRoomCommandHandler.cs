using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.RoomType.Entities;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Create;
public class CreateProjectionCommandHandler : IRequestHandler<CreateRoomCommand, RoomResult>
{
    private readonly IRoomRepository _RoomRepository;
    private readonly IRoomTypeRepository _RoomTypeRepository;

    public CreateProjectionCommandHandler(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
    {
        _RoomRepository = roomRepository;
        _RoomTypeRepository = roomTypeRepository;
    }
    public async Task<RoomResult> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (command.Height <= 0 || command.Width <= 0)
        {
            throw new Exception("Room with the given parameters cannot be created");
        }

        List<RoomType> roomTypes = new();

        command.RoomTypes.ForEach(roomType =>
        {
            RoomType existingRoomType = _RoomTypeRepository.GetByName(roomType.Name)!;
            if (existingRoomType is null)
            {
                throw new Exception($"RoomType '{roomType.Name}' does not exist in the database");
            }
            roomTypes.Add(existingRoomType);
        });

        Room Room = Room.Create(
            command.Height,
            command.Height,
            roomTypes
        );

        _RoomRepository.Add(Room);

        return new RoomResult(Room);
    }
}
