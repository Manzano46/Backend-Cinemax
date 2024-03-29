using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IRoleRepository{
    Role? GetByName(string name);
    Role? GetById(RoleId roleId);
    void Add(Role role);
    void Delete(RoleId role);
    IEnumerable<Role> GetAllRoles();
}
