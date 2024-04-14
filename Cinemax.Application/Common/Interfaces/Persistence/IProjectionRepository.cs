using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.ProjectionAggregate;
using System.Linq.Expressions;
using Cinemax.Domain.Seat.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IProjectionRepository : IRepository<Projection, ProjectionId>
    {
        Projection? GetByKeys(RoomId roomId, MovieId movieId, DateTime date);     
        Task<List<Projection>> GetByAsync(Expression<Func<Projection, bool>> predicate);
        IEnumerable<Seat> GetAllSeats(RoomId roomId);
    }
}
