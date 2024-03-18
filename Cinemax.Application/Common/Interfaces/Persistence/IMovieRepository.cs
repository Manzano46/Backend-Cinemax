using Cinemax.Domain.MovieAggregate.Entities;
using Cinemax.Domain.MovieAggregate.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IMovieRepository{
    Movie? GetMovieByName(string name);
    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(MovieId id);
    IEnumerable<Movie> GetAllMovies();
}
