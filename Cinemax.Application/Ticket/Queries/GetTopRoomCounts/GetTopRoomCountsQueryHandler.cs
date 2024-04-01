using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Infrastructure.Services.Statistics;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetTopRoomCounts;
public class GetTopRoomCountsHandler : IRequestHandler<GetTopRoomCountsQuery, IEnumerable<RoomTicketCount>>
{
    private readonly ITicketRepository _TicketRepository;

    public GetTopRoomCountsHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<IEnumerable<RoomTicketCount>> Handle(GetTopRoomCountsQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var result = await _TicketRepository.GetTopRoomCountsAsync(command.StartDate, command.EndDate, command.Top)!;
        return result ?? new List<RoomTicketCount>();
    }
}
