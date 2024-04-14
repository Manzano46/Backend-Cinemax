using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IActorRepository : IRepository<Actor, ActorId> {
    Actor? GetByName(string LastName, string FirstName);
}
