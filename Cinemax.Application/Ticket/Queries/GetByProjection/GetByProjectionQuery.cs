using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.Get;
public record GetByProjectionQuery(
    ProjectionId ProjectionId
) : IRequest<IEnumerable<TicketResult>>;
