using Cinemax.Domain.Movie.Entities;
using Cinemax.Domain.Movie.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IMovieRepository{
    Movie? GetMovieByName(string name);
    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(MovieId id);
    IEnumerable<Movie> GetAllMovies();
}
