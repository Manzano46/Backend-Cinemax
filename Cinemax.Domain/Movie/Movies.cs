using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Movie.ValueObjects;

namespace Cinemax.Domain.Movie;
public class Movies : AggregateRoot<MoviesId>
{
    public string Description {get;}
    private readonly List<Entities.Movie> _items = new();
    public IReadOnlyList<Entities.Movie> Items => _items.AsReadOnly();
    private Movies(MoviesId moviesId, string description) 
        : base(moviesId){
        Description = description;
    }

    public static Movies Create(string description){
        return new(
            MoviesId.CreateUnique(),
            description
        );
    }

    
}