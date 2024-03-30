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
        if(_CardRepository.GetByNumber(command.number) is not Card Card){
            throw new Exception("Card not found");
        }
        _CardRepository.Delete(command.number);
        return new CardResult(Card);
    }
}