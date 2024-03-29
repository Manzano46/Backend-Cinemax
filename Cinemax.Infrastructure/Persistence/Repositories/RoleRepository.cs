using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class RoleRepository : IRoleRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public RoleRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Role role)
    {
        _cinemaxDbContext.Roles.Add(role);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Role> GetAllRoles()
    {
        return _cinemaxDbContext.Roles;
    }

    public Role? GetByName(string name)
    {
        return _cinemaxDbContext.Roles.SingleOrDefault(m => m.Name == name);
    }
    
       public Role? GetById(RoleId RoleId)
    {
        return _cinemaxDbContext.Roles.SingleOrDefault(m => m.Id == RoleId);
    }
    
    public void Delete(RoleId id)
    {
        var role = _cinemaxDbContext.Roles.SingleOrDefault(m => m.Id == id);
        if (role is not null)
        {
            _cinemaxDbContext.Roles.Remove(role);
            _cinemaxDbContext.SaveChanges();
        }
    }


}
