using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.Seat.Entities;
using Cinemax.Domain.Card.Entities;

namespace Cinemax.Infrastructure.Persistence;
public class CinemaxDbContext : DbContext{
    public CinemaxDbContext(DbContextOptions<CinemaxDbContext> options)
        : base(options) {}
    
    public DbSet<Movie> Movies {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Genre> Genres {get; set;}
    public DbSet<Actor> Actors {get; set;}
    public DbSet<Room> Rooms {get; set;}
    public DbSet<RoomType> RoomTypes {get; set;}
    public DbSet<Country> Countries {get; set;}
    public DbSet<Projection> Projections { get; set;}
    public DbSet<Director> Directors {get; set;}
    public DbSet<Role> Roles {get; set;}
    public DbSet<PaymentType> PaymentTypes {get; set;}
    public DbSet<Discount> Discounts {get; set;}
    public DbSet<Seat> Seats {get; set;}
    public DbSet<Card> Cards {get; set;}
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CinemaxDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}