using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface ICardRepository{
    Card? GetById(CardId CardId);
    void Add(Card Card);
    void Delete(CardId Card);
    IEnumerable<Card> GetAllCards();
}
