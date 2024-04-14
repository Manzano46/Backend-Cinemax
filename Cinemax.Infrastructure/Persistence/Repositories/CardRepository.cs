using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class CardRepository : Repository<Card,CardId>, ICardRepository{

    public CardRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
    }

}
