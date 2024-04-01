using Cinemax.Application.Tickets.Common;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetReserved;
public record GetReservedQuery(
) : IRequest<IEnumerable<TicketResult>>;
