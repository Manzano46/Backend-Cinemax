using Cinemax.Domain.Common.Models;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IRepository<T, TId> 
        where TId : ValueObject
        where T : Entity<TId>
    {
        T? GetById(TId id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(TId id);
    }
}