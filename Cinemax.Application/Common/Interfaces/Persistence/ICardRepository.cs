using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface ICardRepository : IRepository<Card, CardId>{

}
