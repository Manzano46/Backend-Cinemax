using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Delete;
public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, RoomResult>
{
    private readonly IRoomRepository _RoomRepository;
    public DeleteRoomCommandHandler(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;
    }
    public async Task<RoomResult> Handle(DeleteRoomCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_RoomRepository.GetById(command.Id) is not Room room)
        {
            throw new Exception("Room with given id does not exist");
        }

        _RoomRepository.Delete(command.Id);

        return new RoomResult(room);
    }
}
