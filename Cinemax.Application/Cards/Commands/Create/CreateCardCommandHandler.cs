using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Cards.Common;
using Cinemax.Domain.Card.Entities;
using MediatR;




namespace Cinemax.Application.Cards.Commands.Create;
public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, CardResult>
{
    private readonly ICardRepository _CardRepository; 

    public CreateCardCommandHandler(ICardRepository CardRepository)
    {
        _CardRepository = CardRepository;    
    }
    public async Task<CardResult> Handle(CreateCardCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_CardRepository.GetById(command.Id) is not null){
            throw new Exception("Card with given Id already exists");
        }

        Card Card = Card.Create(
            command.Id
        );

        _CardRepository.Insert(Card);

        return new CardResult(Card);
    }

}