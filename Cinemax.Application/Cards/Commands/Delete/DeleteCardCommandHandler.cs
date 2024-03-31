using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.Entities;
using MediatR;

namespace Cinemax.Application.Cards.Commands.Delete;
public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, CardResult>
{
    private readonly ICardRepository _CardRepository; 

    public DeleteCardCommandHandler(ICardRepository CardRepository)
    {
        _CardRepository = CardRepository;    
    }
    public async Task<CardResult> Handle(DeleteCardCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_CardRepository.GetById(command.Id) is not Card card){
            throw new Exception("Card not found");
        }
        _CardRepository.Delete(command.Id);
        return new CardResult(card);
    }
}