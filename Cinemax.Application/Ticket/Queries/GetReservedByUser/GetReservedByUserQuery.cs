using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.User.ValueObjects;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetReservedByUser;
public record GetReservedByUserQuery(
    UserId UserId
) : IRequest<IEnumerable<TicketResult>>;
