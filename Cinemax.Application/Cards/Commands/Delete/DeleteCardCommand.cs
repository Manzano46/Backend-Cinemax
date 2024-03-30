using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.ValueObjects;
using MediatR;

public record DeleteCardCommand(CardNumber number) : IRequest<CardResult>;
