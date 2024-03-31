using Cinemax.Application.Cards.Common;
using MediatR;

namespace Cinemax.Application.Cards.Queries.Read;
public record ReadCardsQuery(
    
) : IRequest<IEnumerable<CardResult>>;
