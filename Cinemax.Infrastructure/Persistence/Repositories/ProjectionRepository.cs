using System.Linq.Expressions;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class ProjectionRepository : IProjectionRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public ProjectionRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Projection Projection)
    {
        _cinemaxDbContext.Projections.Add(Projection);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Projection> GetAll()
    {
        return _cinemaxDbContext.Projections.Include(r => r.Movie).Include(r => r.Room);
    }

    public Projection? GetById(ProjectionId id)
    {
        return _cinemaxDbContext.Projections.Include(r => r.Movie).Include(r => r.Room).SingleOrDefault(m => m.Id == id);
    }
    
    public void Delete(ProjectionId id)
    {
        var Projection = _cinemaxDbContext.Projections.SingleOrDefault(m => m.Id == id);
        if (Projection is not null)
        {
            _cinemaxDbContext.Projections.Remove(Projection);
        }
        _cinemaxDbContext.SaveChanges();
    }

    public Projection? GetByKeys(RoomId roomId, MovieId movieId, DateTime date)
    {
        return _cinemaxDbContext.Projections.Include(r => r.Movie).Include(r => r.Room).SingleOrDefault(m => m.RoomId == roomId && m.MovieId == movieId && m.Date == date);   
    }

    public async Task<List<Projection>> GetByAsync(Expression<Func<Projection, bool>> predicate)
    {
        return await _cinemaxDbContext.Projections.Include(r=>r.Movie).Include(r=>r.Room).Where(predicate).ToListAsync();
    }
}
