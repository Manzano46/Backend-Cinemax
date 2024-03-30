using Cinemax.Domain.Genre.ValueObjects;
using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IGenreRepository
    {
        Genre? GetById(GenreId genreId);
        Genre? GetByName(string name);       
        void Add(Genre genre);
        void Delete(GenreId genreId);
        IEnumerable<Genre> GetAllGenres();
    }
}
