using Cinemax.Domain.RoomType.ValueObjects;
using Cinemax.Domain.RoomType.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IRoomTypeRepository
    {
        RoomType? GetByName(String name);       
        void Add(RoomType RoomType);
        void Delete(String name);
        IEnumerable<RoomType> GetAllRoomTypes();
    }
}
