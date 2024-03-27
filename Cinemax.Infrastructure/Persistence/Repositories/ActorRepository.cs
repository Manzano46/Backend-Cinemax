using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class ActorRepository : IActorRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public ActorRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Actor actor)
    {
        _cinemaxDbContext.Actors.Add(actor);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Actor> GetAllActors()
    {
        return _cinemaxDbContext.Actors;
    }

    public Actor? GetByName(string firstname, string lastname)
    {
        return _cinemaxDbContext.Actors.SingleOrDefault(m => m.FirstName == firstname && m.LastName == lastname);
    }
    
       public Actor? GetById(ActorId actorId)
    {
        return _cinemaxDbContext.Actors.SingleOrDefault(m => m.Id == actorId);
    }
    
    public void Delete(ActorId id)
    {
        var actor = _cinemaxDbContext.Actors.SingleOrDefault(m => m.Id == id);
        if (actor is not null)
        {
            _cinemaxDbContext.Actors.Remove(actor);
            _cinemaxDbContext.SaveChanges();
        }
    }


}
