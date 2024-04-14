using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class RoomRepository : Repository<Room,RoomId>, IRoomRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public RoomRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public Room? GetByName(string name)
    {
        return _cinemaxDbContext.Rooms.SingleOrDefault(r => r.Name == name);
    }
}
