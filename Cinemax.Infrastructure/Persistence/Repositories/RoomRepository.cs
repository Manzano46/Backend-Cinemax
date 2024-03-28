using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Room.Entities;
using Cinemax.Domain.Room.ValueObjects;

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
        return _cinemaxDbContext.Rooms;
    }

    public Room? GetById(RoomId id)
    {
        return _cinemaxDbContext.Rooms.SingleOrDefault(m => m.Id == id);
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
