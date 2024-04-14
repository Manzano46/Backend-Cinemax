using Cinemax.Domain.RoomType.ValueObjects;
using Cinemax.Domain.RoomType.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IRoomTypeRepository : IRepository<RoomType, RoomTypeId>
    {
        RoomType? GetByName(string name);
    }
}
