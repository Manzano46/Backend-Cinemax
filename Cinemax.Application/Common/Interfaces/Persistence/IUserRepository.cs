using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IUserRepository : IRepository<User, UserId>{
    User? GetByEmail(string email);
}