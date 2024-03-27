using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.MovieAggregate.Entities;
using Cinemax.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence;
public class CinemaxDbContext : DbContext{
    public CinemaxDbContext(DbContextOptions<CinemaxDbContext> options)
        : base(options) {}
    
    public DbSet<Movie> Movies {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Genre> Genres {get; set;}
    public DbSet<Actor> Actors {get; set;}
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CinemaxDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}