using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.ValueObjects;
using MediatR;

namespace Cinemax.Application.Cards.Commands.Create;
public record CreateCardCommand(
    CardId Id
) : IRequest<CardResult>;

