using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetReserved;
public class GetReservedQueryHandler : IRequestHandler<GetReservedQuery, IEnumerable<TicketResult>>
{
    private readonly ITicketRepository _TicketRepository;

    public GetReservedQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<IEnumerable<TicketResult>> Handle(GetReservedQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _TicketRepository.GetTicketsReserved().Select(x => new TicketResult(x));
    }
}
