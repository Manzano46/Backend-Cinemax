using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.RoomTypes.Common;
using MediatR;

namespace Cinemax.Application.RoomTypes.Queries.Get;
public class GetRoomTypeQueryHandler : IRequestHandler<GetRoomTypeQuery, RoomTypeResult>
{
    private readonly IRoomTypeRepository _RoomTypeRepository;

    public GetRoomTypeQueryHandler(IRoomTypeRepository RoomTypeRepository)
    {
        _RoomTypeRepository = RoomTypeRepository;
    }
    public async Task<RoomTypeResult> Handle(GetRoomTypeQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_RoomTypeRepository.GetById(command.RoomTypeId)!);
    }
}
