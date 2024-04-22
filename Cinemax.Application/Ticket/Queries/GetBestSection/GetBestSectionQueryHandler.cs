using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetBestSection;
public class GetBestSectionQueryHandler : IRequestHandler<GetBestSectionQuery, IEnumerable<SectionTicketCount>>
{
    private readonly ITicketRepository _TicketRepository;

    public GetBestSectionQueryHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<IEnumerable<SectionTicketCount>> Handle(GetBestSectionQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var result = await _TicketRepository.GetSectionTicketCountsAsync();
        return result ?? new List<SectionTicketCount>();
    }
}
