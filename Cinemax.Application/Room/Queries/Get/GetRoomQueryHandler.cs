using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Rooms.Common;
using MediatR;

namespace Cinemax.Application.Rooms.Queries.Get;
public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomResult>
{
    private readonly IRoomRepository _RoomRepository;

    public GetRoomQueryHandler(IRoomRepository RoomRepository)
    {
        _RoomRepository = RoomRepository;
    }
    public async Task<RoomResult> Handle(GetRoomQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_RoomRepository.GetById(command.RoomId)!);
    }
}
