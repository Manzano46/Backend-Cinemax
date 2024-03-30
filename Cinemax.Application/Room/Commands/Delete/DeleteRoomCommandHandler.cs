using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Rooms.Commands.Delete;
public class DeleteProjectionCommandHandler : IRequestHandler<DeleteProjectionCommand, RoomResult>
{
    private readonly IRoomRepository _RoomRepository;
    public DeleteProjectionCommandHandler(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;
    }
    public async Task<RoomResult> Handle(DeleteProjectionCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_RoomRepository.GetById(command.Id) is not Room Room)
        {
            throw new Exception("Room with given name does not exist");
        }

        _RoomRepository.Delete(command.Id);

        return new RoomResult(Room);
    }
}
