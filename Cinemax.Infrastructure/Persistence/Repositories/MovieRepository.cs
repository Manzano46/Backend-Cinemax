using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.MovieAggregate.Entities;
using Cinemax.Domain.MovieAggregate.ValueObjects;


namespace Cinemax.Infrastructure.Persistence.Repositories;
public class MovieRepository : IMovieRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public MovieRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Movie movie)
    {
        _cinemaxDbContext.Add(movie);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _cinemaxDbContext.Movies;
    }

    public Movie? GetMovieByName(string name)
    {
        return _cinemaxDbContext.Movies.SingleOrDefault(m => m.Name == name);
    }
    /*
    public void Delete(MovieId id)
    {
        var movie = _movies.SingleOrDefault(m => m.Id == id);
        if (movie is not null)
        {
            _movies.Remove(movie);
        }
    }



    public void Update(Movie movie)
    {
        var existingMovie = _movies.SingleOrDefault(m => m.Id == movie.Id);
        if (existingMovie is not null)
        {
            existingMovie.Name = movie.Name;
            existingMovie.Description = movie.Description;
            existingMovie.Duration = movie.Duration;
            existingMovie.Premiere = movie.Premiere;
            existingMovie.IconURL = movie.IconURL;
            existingMovie.TrailerURL = movie.TrailerURL;
        }
    }*/
}
