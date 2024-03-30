using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.RoomType.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class RoomTypeRepository : IRoomTypeRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public RoomTypeRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(RoomType RoomType)
    {
        _cinemaxDbContext.RoomTypes.Add(RoomType);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<RoomType> GetAllRoomTypes()
    {   
        return _cinemaxDbContext.RoomTypes.Include(r => r.Rooms);
    }

    public RoomType? GetByName(string name)
    {
        return _cinemaxDbContext.RoomTypes.Include(r => r.Rooms).SingleOrDefault(m => m.Name == name);
    }
    
    public void Delete(string name)
    {
        var RoomType = _cinemaxDbContext.RoomTypes.SingleOrDefault(m => m.Name == name);
        if (RoomType is not null)
        {
            _cinemaxDbContext.RoomTypes.Remove(RoomType);
        }
        _cinemaxDbContext.SaveChanges();
    }

    public RoomType? GetById(RoomTypeId roomTypeId)
    {
         return _cinemaxDbContext.RoomTypes.Include(r => r.Rooms).SingleOrDefault(m => m.Id == roomTypeId);
    }
}
