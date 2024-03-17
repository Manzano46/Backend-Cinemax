using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Movie;

namespace Cinemax.Infrastructure.Persistence;
public class MovieRepository : IMovieRepository{
    private static readonly List<Movie> _movies = new();

    public void Add(Movie movie)
    {
        _movies.Add(movie);
    }

    public void Delete(Guid id)
    {
        var movie = _movies.SingleOrDefault(m => m.Id == id);
        if (movie != null)
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
        if (existingMovie != null)
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
