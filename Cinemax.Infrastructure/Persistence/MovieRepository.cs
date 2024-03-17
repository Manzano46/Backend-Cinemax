using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Movie.Entities;
using Cinemax.Domain.Movie.ValueObjects;


namespace Cinemax.Infrastructure.Persistence;
public class MovieRepository : IMovieRepository{
    private static readonly List<Movie> _movies = new();

    public void Add(Movie movie)
    {
        _movies.Add(movie);
    }

    public void Delete(MovieId id)
    {
        var movie = _movies.SingleOrDefault(m => m.Id == id);
        if (movie is not null)
        {
            _movies.Remove(movie);
        }
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _movies;
    }

    public Movie? GetMovieByName(string name)
    {
        return _movies.SingleOrDefault(m => m.Name == name);
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
    }
}
