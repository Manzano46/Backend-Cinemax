using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Get;
public class GetByProjectionQueryHandler : IRequestHandler<GetByProjectionQuery, IEnumerable<TicketResult>>
{
    private readonly ITicketRepository _TicketRepository;

    public GetByProjectionQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<IEnumerable<TicketResult>> Handle(GetByProjectionQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _TicketRepository.GetTicketByProjection(command.ProjectionId).Select(x => new TicketResult(x));
    }
}
