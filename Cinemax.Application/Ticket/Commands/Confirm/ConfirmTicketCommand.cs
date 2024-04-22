using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.PaymentType.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.User.ValueObjects;
using MediatR;

namespace Cinemax.Application.Tickets.Commands.Confirm;
public record ConfirmTicketCommand(
    SeatId  SeatId,
    UserId UserId,
    ProjectionId ProjectionId,
    DateTime Date,
    PaymentTypeId PaymentTypeId
) : IRequest<TicketResult>;
