using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IRoleRepository : IRepository<Role, RoleId>{
    Role? GetByName(string name);
}
