using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class DirectorRepository : IDirectorRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public DirectorRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Director director)
    {
        _cinemaxDbContext.Directors.Add(director);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Director> GetAllDirectors()
    {
        return _cinemaxDbContext.Directors;
    }

    public Director? GetByName(string firstname, string lastname)
    {
        return _cinemaxDbContext.Directors.SingleOrDefault(m => m.FirstName == firstname && m.LastName == lastname);
    }
    
       public Director? GetById(DirectorId DirectorId)
    {
        return _cinemaxDbContext.Directors.SingleOrDefault(m => m.Id == DirectorId);
    }
    
    public void Delete(DirectorId id)
    {
        var Director = _cinemaxDbContext.Directors.SingleOrDefault(m => m.Id == id);
        if (Director is not null)
        {
            _cinemaxDbContext.Directors.Remove(Director);
            _cinemaxDbContext.SaveChanges();
        }
    }


}
