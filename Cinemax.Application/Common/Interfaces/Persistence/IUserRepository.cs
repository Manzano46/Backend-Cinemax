using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IUserRepository{
    User? GetById(UserId userId);
    User? GetUserByEmail(string Email);
    void Add(User user);
    void Delete(UserId userId);
    IEnumerable<User> GetAll();
}