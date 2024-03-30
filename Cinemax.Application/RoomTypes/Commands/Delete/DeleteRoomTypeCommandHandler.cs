using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Domain.RoomType.Entities;
using MediatR;

namespace Cinemax.Application.RoomTypes.Commands.Delete;
public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, RoomTypeResult>
{
    private readonly IRoomTypeRepository _RoomTypeRepository;
    public DeleteRoomTypeCommandHandler(IRoomTypeRepository RoomTypeRepository)
    {
        _RoomTypeRepository = RoomTypeRepository;
    }
    public async Task<RoomTypeResult> Handle(DeleteRoomTypeCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_RoomTypeRepository.GetByName(command.Name) is not RoomType RoomType)
        {
            throw new Exception("RoomType with given name does not exist");
        }

        _RoomTypeRepository.Delete(command.Name);

        return new RoomTypeResult(RoomType);
    }
}
