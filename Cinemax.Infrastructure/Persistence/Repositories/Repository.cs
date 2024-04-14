using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;

public class Repository<T, TId> : IRepository<T,TId>
    where TId : ValueObject
    where T : Entity<TId>
{
    protected readonly CinemaxDbContext _context;
    protected DbSet<T> _entities;

    public Repository(CinemaxDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public virtual T? GetById(TId id)
    {
        return _entities.Find(id);
    }

    public virtual IEnumerable<T> GetAll()
    {
        return _entities.AsEnumerable();
    }

    public virtual void Insert(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _entities.Add(entity);
        _context.SaveChanges();
    }

    public virtual void Update(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _context.SaveChanges();
    }

    public virtual void Delete(TId id)
    {
        var entity = _entities.Find(id);
        if (entity is not null)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
