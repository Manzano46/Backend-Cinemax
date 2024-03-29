using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Genre.Entities;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class GenreRepository : IGenreRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public GenreRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Genre Genre)
    {
        _cinemaxDbContext.Genres.Add(Genre);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        return _cinemaxDbContext.Genres;
    }

    public Genre? GetByName(string name)
    {
        return _cinemaxDbContext.Genres.SingleOrDefault(m => m.Name == name);
    }
    
    public void Delete(string name)
    {
        var Genre = _cinemaxDbContext.Genres.SingleOrDefault(m => m.Name == name);
        if (Genre is not null)
        {
            _cinemaxDbContext.Genres.Remove(Genre);
        }
        _cinemaxDbContext.SaveChanges();
    }
}
