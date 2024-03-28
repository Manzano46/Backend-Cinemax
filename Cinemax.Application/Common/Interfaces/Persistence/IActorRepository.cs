using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IActorRepository{
    Actor? GetByName(string firstname,string lastname);
    Actor? GetById(ActorId actorId);
    void Add(Actor actor);
    void Delete(ActorId actor);
    IEnumerable<Actor> GetAllActors();
}
