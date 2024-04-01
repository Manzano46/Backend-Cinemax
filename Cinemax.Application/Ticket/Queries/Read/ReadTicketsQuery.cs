using Cinemax.Application.Tickets.Common;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Read;
public record ReadTicketQuery(

) : IRequest<IEnumerable<TicketResult>>;
