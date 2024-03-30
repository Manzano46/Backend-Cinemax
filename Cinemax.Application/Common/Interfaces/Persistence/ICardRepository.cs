using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface ICardRepository{
    Card? GetByNumber(CardNumber CardId);
    void Add(Card Card);
    void Delete(CardNumber Card);
    IEnumerable<Card> GetAllCards();
}
