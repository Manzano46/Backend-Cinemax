using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.ProjectionAggregate;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IProjectionRepository
    {
        Projection? GetByKeys(RoomId roomId, MovieId movieId, DateTime date);
        Projection? GetById(ProjectionId id);       
        void Add(Projection Projection);
        void Delete(ProjectionId id);
        IEnumerable<Projection> GetAll();
    }
}
