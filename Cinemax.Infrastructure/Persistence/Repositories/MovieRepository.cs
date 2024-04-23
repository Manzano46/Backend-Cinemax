using System.Diagnostics;
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

    public override IEnumerable<Movie> GetAll()
    {
        return _cinemaxDbContext.Movies.Include(m => m.Genres).Include(m => m.Actors).Include(m => m.Directors).Include(m => m.Countries);
    }

    public IEnumerable<Movie> Filter(string[,] attr)
    {
        return _cinemaxDbContext.Movies.Include(m => m.Genres).Include(m => m.Actors).Include(m => m.Directors).Include(m => m.Countries).Where(x => lambda(x,attr));
    }
    public override Movie? GetById(MovieId movieId)
    {
        return _cinemaxDbContext.Movies.Include(m => m.Genres).Include(m => m.Actors).Include(m => m.Directors).Include(m => m.Countries).SingleOrDefault(m => m.Id == movieId);
    }
    static bool lambda(dynamic x, string[,] attr){
        bool cond = true;
        for(int i=0;i<attr.Length;i++){
            cond = cond && x.GetProperty(attr[i,0]).GetValue(x).ToString() == attr[i,1];
        }
        return cond;
    }
}
