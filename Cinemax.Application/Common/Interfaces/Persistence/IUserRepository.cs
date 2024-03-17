using Cinemax.Domain.User;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IUserRepository{
    User? GetUserByEmail(string Email);
    void Add(User user);
}