using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class DirectorRepository : Repository<Director, DirectorId>, IDirectorRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public DirectorRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }
    
    public Director? GetByName(string LastName, string FirstName)
    {
        return _cinemaxDbContext.Directors.SingleOrDefault(d => d.LastName == LastName && d.FirstName == FirstName);
    }
}
