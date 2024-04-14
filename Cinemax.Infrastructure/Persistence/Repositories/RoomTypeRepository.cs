using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.RoomType.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class RoomTypeRepository : Repository<RoomType,RoomTypeId>, IRoomTypeRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public RoomTypeRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public RoomType? GetByName(string name)
    {
        return _cinemaxDbContext.RoomTypes.SingleOrDefault(r => r.Name == name);
    }
}
