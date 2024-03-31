using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.Seat.Entities;
using Cinemax.Domain.Seat.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class SeatRepository : ISeatRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public SeatRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Seat seat)
    {
        _cinemaxDbContext.Seats.Add(seat);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Seat> GetAll()
    {
        return _cinemaxDbContext.Seats.Include(r => r.Room);
    }

    public Seat? GetById(SeatId id)
    {
        return _cinemaxDbContext.Seats.Include(r => r.Room).SingleOrDefault(m => m.Id == id);
    }
    
    public void Delete(SeatId id)
    {
        var Seat = _cinemaxDbContext.Seats.SingleOrDefault(m => m.Id == id);
        if (Seat is not null)
        {
            _cinemaxDbContext.Seats.Remove(Seat);
        }
        _cinemaxDbContext.SaveChanges();
    }
}
