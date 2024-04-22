using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Refund;
public record RefundTicketQuery(
    TicketId TicketId
) : IRequest<TicketResult>;
