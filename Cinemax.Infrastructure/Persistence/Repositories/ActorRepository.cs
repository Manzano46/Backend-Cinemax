using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class ActorRepository : Repository<Actor,ActorId>, IActorRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;
    public ActorRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public Actor? GetByName(string FirstName, string LastName)
    {
        return _cinemaxDbContext.Actors.SingleOrDefault(a => a.FirstName == FirstName && a.LastName == LastName);
    }
}
