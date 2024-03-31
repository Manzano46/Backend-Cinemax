using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IRoomRepository
    {
        Room? GetById(RoomId id); 
        Room? GetByName(string name);       
        void Add(Room Room);
        void Delete(RoomId id);
        IEnumerable<Room> GetAll();
    }
}
