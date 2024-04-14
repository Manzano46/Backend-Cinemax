using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IRoomRepository : IRepository<Room, RoomId>
    {
        Room? GetByName(string name);
    }
}
