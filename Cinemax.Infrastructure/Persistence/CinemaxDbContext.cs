using Cinemax.Domain.MovieAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence;
public class CinemaxDbContext : DbContext{
    public CinemaxDbContext(DbContextOptions<CinemaxDbContext> options)
        : base(options) {}
    
    public DbSet<Movie> Movies {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CinemaxDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}