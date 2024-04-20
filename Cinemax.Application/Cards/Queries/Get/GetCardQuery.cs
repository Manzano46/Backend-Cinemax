using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.ValueObjects;
using MediatR;

namespace Cinemax.Application.Cards.Queries.Get;
public record GetCardQuery(
    CardId CardId
) : IRequest<CardResult>;
