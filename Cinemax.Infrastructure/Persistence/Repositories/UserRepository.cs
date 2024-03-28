using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.User.Entities;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class UserRepository : IUserRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;
    public UserRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }
    public void Add(User user){
        _cinemaxDbContext.Users.Add(user);
        _cinemaxDbContext.SaveChanges();
    }

    public User? GetUserByEmail(string Email){
        return _cinemaxDbContext.Users.SingleOrDefault(user => user.Email == Email); 
    }
}