using Cinemax.Application.Tickets.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Tickets.Queries.GetBestSection;
public record GetBestSectionQuery(
) : IRequest<IEnumerable<SectionTicketCount>>;
