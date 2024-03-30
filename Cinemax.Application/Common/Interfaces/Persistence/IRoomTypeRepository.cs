using Cinemax.Domain.RoomType.ValueObjects;
using Cinemax.Domain.RoomType.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IRoomTypeRepository
    {
        RoomType? GetById(RoomTypeId roomTypeId);
        RoomType? GetByName(String name);       
        void Add(RoomType RoomType);
        void Delete(RoomTypeId roomTypeId);
        IEnumerable<RoomType> GetAllRoomTypes();
    }
}
