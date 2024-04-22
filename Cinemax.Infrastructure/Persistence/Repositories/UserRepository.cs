using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class UserRepository : Repository<User,UserId> , IUserRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public UserRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public User? GetByEmail(string email)
    {
        return _cinemaxDbContext.Users.Include(r=> r.Role).SingleOrDefault(u => u.Email == email);
    }

    public override IEnumerable<User> GetAll()
    {
        return _cinemaxDbContext.Users.Include(r=> r.Role).Include(r => r.Cards).Include(r => r.Tickets);
    }

    public override User? GetById(UserId id)
    {
        return _cinemaxDbContext.Users.Include(r=> r.Role).Include(r => r.Cards).Include(r => r.Tickets).SingleOrDefault(u => u.Id == id);
    }
}