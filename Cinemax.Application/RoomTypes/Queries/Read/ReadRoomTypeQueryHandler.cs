using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.RoomTypes.Common;
using MediatR;

namespace Cinemax.Application.RoomTypes.Queries.Read;
public class ReadRoomTypesQueryHandler : IRequestHandler<ReadRoomTypesQuery, IEnumerable<RoomTypeResult>>
{
    private readonly IRoomTypeRepository _RoomTypeRepository;

    public ReadRoomTypesQueryHandler(IRoomTypeRepository RoomTypeRepository)
    {
        _RoomTypeRepository = RoomTypeRepository;
    }
    public async Task<IEnumerable<RoomTypeResult>> Handle(ReadRoomTypesQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _RoomTypeRepository.GetAllRoomTypes().Select(x => new RoomTypeResult(x));
    }
}
