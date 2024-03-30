using Cinemax.Domain.MovieAggregate.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IMovieRepository{
    Movie? GetByName(string name);
    void Add(Movie movie);
    //void Update(Movie movie);
    //void Delete(MovieId id);
    IEnumerable<Movie> GetAllMovies();
}
