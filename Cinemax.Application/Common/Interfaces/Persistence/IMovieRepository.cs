using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IMovieRepository{
    Movie? GetById(MovieId movieId);
    Movie? GetByName(string name);
    void Add(Movie movie);
    //void Update(Movie movie);
    void Delete(MovieId movieId);
    IEnumerable<Movie> GetAll();
}
