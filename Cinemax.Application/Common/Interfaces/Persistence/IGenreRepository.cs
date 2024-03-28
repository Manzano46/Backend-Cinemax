using Cinemax.Domain.Genre.ValueObjects;
using Cinemax.Domain.Genre.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface IGenreRepository
    {
        Genre? GetByName(String name);       
        void Add(Genre genre);
        void Delete(String name);
        IEnumerable<Genre> GetAllGenres();
    }
}
