using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetReservedByUser;
public class GetReservedByUserQueryHandler : IRequestHandler<GetReservedByUserQuery, IEnumerable<TicketResult>>
{
    private readonly ITicketRepository _TicketRepository;

    public GetReservedByUserQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<IEnumerable<TicketResult>> Handle(GetReservedByUserQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _TicketRepository.GetTicketsReservedByUser(command.UserId).Select(x => new TicketResult(x));
    }
}
