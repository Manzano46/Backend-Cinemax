using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.Seat.Entities;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Create;
public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomResult>
{
    private readonly IRoomRepository _RoomRepository;
    private readonly IRoomTypeRepository _RoomTypeRepository;
    private readonly ISeatRepository _SeatRepository;
    

    public CreateRoomCommandHandler(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, ISeatRepository _seatRepository)
    {
        _RoomRepository = roomRepository;
        _RoomTypeRepository = roomTypeRepository;
        _SeatRepository = _seatRepository;
    }
    public async Task<RoomResult> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (command.Height <= 0 || command.Width <= 0)
        {
            throw new Exception("Room with the given parameters cannot be created");
        }

        if(_RoomRepository.GetByName(command.Name) is not null)
        {
            throw new Exception($"Room with name '{command.Name}' already exists in the database");
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
            command.Width,
            command.Name,
            roomTypes
        );
        
        List<Seat> seats = new();
        for(int i=0;i<command.Height;i++){
            for(int j=0;j<command.Width;j++){
                Seat seat = Seat.Create(Room.Id, Room,i,j);
                seats.Add(seat);
            }
        }

        Room.Seats = seats;

        _RoomRepository.Add(Room);

        return new RoomResult(Room);
    }
}
