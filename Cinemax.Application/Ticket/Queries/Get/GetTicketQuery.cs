using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Get;
public record GetTicketQuery(
    TicketId TicketId
) : IRequest<TicketResult>;
