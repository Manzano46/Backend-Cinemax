using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.RoomType.Entities;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Create;
public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomResult>
{
    private readonly IRoomRepository _RoomRepository;
    private readonly IRoomTypeRepository _RoomTypeRepository;

    public CreateRoomCommandHandler(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
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

        command.RoomTypesId.ForEach(Id =>
        {
            RoomType existingRoomType = _RoomTypeRepository.GetById(Id)!;
            if (existingRoomType is null)
            {
                throw new Exception($"RoomType '{Id}' does not exist in the database");
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
