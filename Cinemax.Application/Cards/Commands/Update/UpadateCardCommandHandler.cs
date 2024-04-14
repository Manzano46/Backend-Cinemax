using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.Entities;
using MediatR;
using Cinemax.Domain.Card.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Cards.Commands.Update;
public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, CardResult>
{
    private readonly ICardRepository _CardRepository; 

    public UpdateCardCommandHandler(ICardRepository CardRepository)
    {
        _CardRepository = CardRepository;    
    }
    public async Task<CardResult> Handle(UpdateCardCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var cardId = CardId.Create(command.Id);
        var Card = _CardRepository.GetById(cardId);

        if (Card is null)
        {
            throw new Exception("Card with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Card);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Card", ex);
        }
        
        _CardRepository.Update(Card);

        return new CardResult(Card);
    }
}