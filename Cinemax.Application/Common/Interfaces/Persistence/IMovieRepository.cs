using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IMovieRepository : IRepository<Movie, MovieId>{
    Movie? GetByName(string name);
}
