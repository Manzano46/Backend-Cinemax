using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Tickets.Commands.Delete;
public record DeleteTicketCommand(
    TicketId Id
) : IRequest<TicketResult>;
