using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.User.ValueObjects;
using Cinemax.Infrastructure.Services.Statistics;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetTopRoomCounts;
public record GetTopRoomCountsQuery(
    DateTime StartDate,
    DateTime EndDate,
    int Top
) : IRequest<IEnumerable<RoomTicketCount>>;
