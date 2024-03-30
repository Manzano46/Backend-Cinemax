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
        if(_CardRepository.GetByNumber(command.Number) is not null){
            throw new Exception("Card with given number already exists");
        }

        Card Card = Card.Create(
            command.Number
        );

        _CardRepository.Add(Card);

        return new CardResult(Card);
    }

}