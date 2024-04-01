using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.User.ValueObjects;
using MediatR;

namespace Cinemax.Application.Tickets.Commands.Create;
public record CreateTicketCommand(
    SeatId  SeatId,
    UserId UserId,
    ProjectionId ProjectionId,
    DateTime Date
) : IRequest<TicketResult>;
