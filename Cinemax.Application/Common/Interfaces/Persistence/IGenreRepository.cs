using Cinemax.Domain.Genre.ValueObjects;
using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IGenreRepository : IRepository<Genre, GenreId>
    {
        Genre? GetByName(string name);
    }
}
