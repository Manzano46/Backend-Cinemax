using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateCardCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<CardResult>;
