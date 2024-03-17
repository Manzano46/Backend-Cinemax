using Cinemax.Domain.Movie;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IMovieRepository{
    Movie? GetMovieByName(string name);
    void Add(Movie movie);
    void Update(Movie movie);
    void Delete(Guid id);
    IEnumerable<Movie> GetAllMovies();
}
