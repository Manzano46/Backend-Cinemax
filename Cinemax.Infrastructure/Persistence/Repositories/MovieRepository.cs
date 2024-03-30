using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class MovieRepository : IMovieRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public MovieRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Movie movie)
    {
        _cinemaxDbContext.Movies.Add(movie);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Movie> GetAll()
    {
        return _cinemaxDbContext.Movies;
    }

    public Movie? GetById(MovieId movieId)
    {
        return _cinemaxDbContext.Movies.SingleOrDefault(m => m.Id == movieId);
    }
    
    public void Delete(MovieId id)
    {
        var movie = _cinemaxDbContext.Movies.SingleOrDefault(m => m.Id == id);
        if (movie is not null)
        {
            _cinemaxDbContext.Movies.Remove(movie);
        }
        _cinemaxDbContext.SaveChanges();
    }

    public Movie? GetByName(string name)
    {
        return _cinemaxDbContext.Movies.SingleOrDefault(m => m.Name == name);
    }
}
