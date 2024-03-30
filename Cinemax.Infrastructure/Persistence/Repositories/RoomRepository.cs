using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class RoomRepository : IRoomRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public RoomRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Room Room)
    {
        _cinemaxDbContext.Rooms.Add(Room);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Room> GetAll()
    {
        return _cinemaxDbContext.Rooms.Include(r => r.RoomTypes);
    }

    public Room? GetById(RoomId id)
    {
        return _cinemaxDbContext.Rooms.Include(r => r.RoomTypes).SingleOrDefault(m => m.Id == id);
    }
    
    public void Delete(RoomId id)
    {
        var Room = _cinemaxDbContext.Rooms.SingleOrDefault(m => m.Id == id);
        if (Room is not null)
        {
            _cinemaxDbContext.Rooms.Remove(Room);
        }
        _cinemaxDbContext.SaveChanges();
    }
}
