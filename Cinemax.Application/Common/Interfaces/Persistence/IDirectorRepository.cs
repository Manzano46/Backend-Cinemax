using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IDirectorRepository : IRepository<Director, DirectorId>{
    Director? GetByName(string LastName, string FirstName);
}
