using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IDirectorRepository{
    Director? GetByName(string firstname,string lastname);
    Director? GetById(DirectorId directorId);
    void Add(Director director);
    void Delete(DirectorId director);
    IEnumerable<Director> GetAllDirectors();
}
