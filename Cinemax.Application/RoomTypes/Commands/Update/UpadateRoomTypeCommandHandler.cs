using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Domain.RoomType.Entities;
using MediatR;
using Cinemax.Domain.RoomType.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.RoomTypes.Commands.Update;
public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, RoomTypeResult>
{
    private readonly IRoomTypeRepository _RoomTypeRepository; 

    public UpdateRoomTypeCommandHandler(IRoomTypeRepository RoomTypeRepository)
    {
        _RoomTypeRepository = RoomTypeRepository;    
    }
    public async Task<RoomTypeResult> Handle(UpdateRoomTypeCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var roomTypeId = RoomTypeId.Create(new (command.Id));
        var RoomType = _RoomTypeRepository.GetById(roomTypeId);

        if (RoomType is null)
        {
            throw new Exception("RoomType with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(RoomType);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the RoomType", ex);
        }
        
        _RoomTypeRepository.Update(RoomType);

        return new RoomTypeResult(RoomType);
    }
}