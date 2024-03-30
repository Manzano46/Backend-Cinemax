using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class CardRepository : ICardRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public CardRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Card Card)
    {
        _cinemaxDbContext.Cards.Add(Card);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Card> GetAllCards()
    {
        return _cinemaxDbContext.Cards;
    }

    
    public Card? GetByNumber(CardNumber CardNumber)
    {
        return _cinemaxDbContext.Cards.SingleOrDefault(m => m.Number == CardNumber);
    }
    
    public void Delete(CardNumber number)
    {
        var Card = _cinemaxDbContext.Cards.SingleOrDefault(m => m.Number == number);
        if (Card is not null)
        {
            _cinemaxDbContext.Cards.Remove(Card);
            _cinemaxDbContext.SaveChanges();
        }
    }


}
