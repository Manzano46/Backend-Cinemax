using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Cards.Common;
using Cinemax.Application.Cards.Queries.Read;
using MediatR;

namespace Cinemax.Application.Cards.Query.Read;
public class ReadCardsQueryHandler : IRequestHandler<ReadCardsQuery, IEnumerable<CardResult>>
{
    private readonly ICardRepository _CardRepository; 

    public ReadCardsQueryHandler(ICardRepository CardRepository)
    {
        _CardRepository = CardRepository;    
    }
    public async Task<IEnumerable<CardResult>> Handle(ReadCardsQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _CardRepository.GetAll().Select(x => new CardResult(x));
    }
}
