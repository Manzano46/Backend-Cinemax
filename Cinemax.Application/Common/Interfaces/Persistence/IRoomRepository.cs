using Cinemax.Domain.Room.ValueObjects;
using Cinemax.Domain.Room.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IRoomRepository
    {
        Room? GetById(RoomId id);       
        void Add(Room Room);
        void Delete(RoomId id);
        IEnumerable<Room> GetAll();
    }
}
