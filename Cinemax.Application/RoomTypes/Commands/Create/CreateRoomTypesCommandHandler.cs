using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Domain.RoomType.Entities;
using MediatR;

namespace Cinemax.Application.RoomTypes.Commands.Create;
public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, RoomTypeResult>
{
    private readonly IRoomTypeRepository _RoomTypeRepository;
    public CreateRoomTypeCommandHandler(IRoomTypeRepository RoomTypeRepository)
    {
        _RoomTypeRepository = RoomTypeRepository;
    }
    public async Task<RoomTypeResult> Handle(CreateRoomTypeCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_RoomTypeRepository.GetByName(command.Name) is not null)
        {
            throw new Exception("RoomType with given name alredy exists");
        }

        RoomType RoomType = RoomType.Create(
            command.Name
        );

        _RoomTypeRepository.Insert(RoomType);

        return new RoomTypeResult(RoomType);
    }
}
