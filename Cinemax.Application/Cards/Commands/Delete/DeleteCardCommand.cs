using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.ValueObjects;
using MediatR;

public record DeleteCardCommand(CardId Id) : IRequest<CardResult>;
