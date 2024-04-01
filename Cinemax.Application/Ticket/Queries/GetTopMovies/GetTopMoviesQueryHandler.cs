using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Infrastructure.Services.Statistics;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetTopMovies;
public class GetTopMoviesHandler : IRequestHandler<GetTopMoviesQuery, IEnumerable<TopMovie>>
{
    private readonly ITicketRepository _TicketRepository;

    public GetTopMoviesHandler(ITicketRepository TicketRepository)
    {
        _TicketRepository = TicketRepository;
    }
    public async Task<IEnumerable<TopMovie>> Handle(GetTopMoviesQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var result = await _TicketRepository.GetTopMoviesAsync(command.StartDate, command.EndDate, command.Top)!;
        return result ?? new List<TopMovie>();
    }
}
