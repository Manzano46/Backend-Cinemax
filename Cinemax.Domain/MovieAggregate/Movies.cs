using Cinemax.Domain.Common.Models;
using Cinemax.Domain.MovieAggregate.ValueObjects;
using Cinemax.Domain.MovieAggregate.Entities;

namespace Cinemax.Domain.MovieAggregate;
public class Movies : AggregateRoot<MoviesId>
{
    public string Description {get;}
    private readonly List<Movie> _items = new();
    public IReadOnlyList<Movie> Items => _items.AsReadOnly();
    #pragma warning disable CS8618
    private Movies(){}
    #pragma warning restore CS8618
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