using Cinemax.Domain.User.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IUserRepository{
    User? GetUserByEmail(string Email);
    void Add(User user);
}