using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

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

    public User? GetById(UserId userId)
    {
        return _cinemaxDbContext.Users.Include(r => r.Cards).Include(r=>r.Role).SingleOrDefault(user => user.Id == userId);
    }

    public User? GetUserByEmail(string email){
        return _cinemaxDbContext.Users.Include(r => r.Cards).Include(r=>r.Role).SingleOrDefault(user => user.Email == email); 
    }

    public void Delete(UserId userId){
        User user = _cinemaxDbContext.Users.SingleOrDefault(user => user.Id == userId)!;
        if(user is not null){
            _cinemaxDbContext.Users.Remove(user);
        }
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
        return _cinemaxDbContext.Users.Include(r => r.Cards).Include(r=>r.Role);
    }

   
}