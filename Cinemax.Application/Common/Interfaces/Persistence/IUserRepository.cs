using Cinemax.Domain.Entities;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IUserRepository{
    User? GetUserByEmail(string Email);
    void Add(User user);
}