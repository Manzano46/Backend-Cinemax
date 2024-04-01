using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.Entities;
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

    public IEnumerable<Seat> GetAllSeats(RoomId roomId)
    {
        return _cinemaxDbContext.Seats.Where(s => s.RoomId == roomId);
    }
    public Projection? GetById(ProjectionId id)
    {
        return _cinemaxDbContext.Projections.Include(r => r.Movie).Include(r => r.Room).SingleOrDefault(m => m.Id == id);
    }
    
    public void Delete(ProjectionId id)
    {
        var Projection = _cinemaxDbContext.Projections.SingleOrDefault(m => m.Id == id);
        var range = _cinemaxDbContext.Tickets.Where(x => x.ProjectionId == id);
        _cinemaxDbContext.Tickets.RemoveRange(range);
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

}
