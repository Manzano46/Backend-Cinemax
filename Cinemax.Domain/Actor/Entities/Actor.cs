using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Actor.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Domain.Actor.Entities;
public class Actor: Entity<ActorId>{
    public string FirstName {get;set;} = null!;
    public string LastName {get;set;} = null!;
    public virtual ICollection<Movie> Movies { get; set; } = null!;
     

    #pragma warning disable CS8618
    private Actor(){}
    #pragma warning restore CS8618
    private Actor(ActorId actorId, string firstName, string lastName, ICollection<Movie> movies = null!)
        : base(actorId){
            FirstName = firstName;
            LastName = lastName;
            Movies = movies ?? new List<Movie>();
    }

    public static Actor Create(string firstName, string lastName, ICollection<Movie> movies = null!){
        return new(ActorId.CreateUnique(), firstName, lastName, movies);
    }

}