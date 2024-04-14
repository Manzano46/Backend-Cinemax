using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class MovieRepository : Repository<Movie,MovieId> , IMovieRepository{

    private readonly CinemaxDbContext _cinemaxDbContext;
    public MovieRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public Movie? GetByName(string name)
    {
        return _cinemaxDbContext.Movies.SingleOrDefault(m => m.Name == name);
    }
}
