using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Get;
public class GetTicketQueryHandler : IRequestHandler<GetTicketQuery, TicketResult>
{
    private readonly ITicketRepository _TicketRepository;

    public GetTicketQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<TicketResult> Handle(GetTicketQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_TicketRepository.GetById(command.TicketId)!);
    }
}
