using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Cards.Common;
using MediatR;

namespace Cinemax.Application.Cards.Queries.Get;
public class GetCardQueryHandler : IRequestHandler<GetCardQuery, CardResult>
{
    private readonly ICardRepository _CardRepository;

    public GetCardQueryHandler(ICardRepository CardRepository)
    {
        _CardRepository = CardRepository;
    }
    public async Task<CardResult> Handle(GetCardQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_CardRepository.GetById(command.CardId)!);
    }
}
