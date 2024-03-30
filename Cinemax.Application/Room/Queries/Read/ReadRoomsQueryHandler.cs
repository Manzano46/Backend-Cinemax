using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using MediatR;

namespace Cinemax.Application.Rooms.Queries.Read;
public class ReadRoomQueryHandler : IRequestHandler<ReadRoomQuery, IEnumerable<RoomResult>>
{
    private readonly IRoomRepository _RoomRepository;

    public ReadRoomQueryHandler(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;
    }
    public async Task<IEnumerable<RoomResult>> Handle(ReadRoomQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _RoomRepository.GetAll().Select(x => new RoomResult(x));
    }
}
