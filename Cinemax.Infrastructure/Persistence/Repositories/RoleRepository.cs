using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class RoleRepository : Repository<Role,RoleId> , IRoleRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public RoleRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public Role? GetByName(string name)
    {
        return _cinemaxDbContext.Roles.SingleOrDefault(r => r.Name == name);
    }
}
