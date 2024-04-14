using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Rooms.Commands.Update;
public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomResult>
{
    private readonly IRoomRepository _RoomRepository; 

    public UpdateRoomCommandHandler(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;    
    }
    public async Task<RoomResult> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var roomId = RoomId.Create(new (command.Id));
        var Room = _RoomRepository.GetById(roomId);

        if (Room is null)
        {
            throw new Exception("Room with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Room);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Room", ex);
        }
        
        _RoomRepository.Update(Room);

        return new RoomResult(Room);
    }
}