using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.Genre.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class GenreRepository : Repository<Genre,GenreId> ,IGenreRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;
    public GenreRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public Genre? GetByName(string name)
    {
        return _cinemaxDbContext.Genres.SingleOrDefault(g => g.Name == name);
    }
}
