using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Read;
public class ReadTicketQueryHandler : IRequestHandler<ReadTicketQuery, IEnumerable<TicketResult>>
{
    private readonly ITicketRepository _TicketRepository;

    public ReadTicketQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<IEnumerable<TicketResult>> Handle(ReadTicketQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _TicketRepository.GetAll().Select(x => new TicketResult(x));
    }
}
