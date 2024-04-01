using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Director.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Domain.Director.Entities;
public class Director: Entity<DirectorId>{
    public string FirstName {get;set;} = null!;
    public string LastName {get;set;} = null!;
    public virtual ICollection<Movie> Movies { get; set; } = null!;
     

    #pragma warning disable CS8618
    private Director(){}
    #pragma warning restore CS8618
    private Director(DirectorId directorId, string firstName, string lastName,ICollection<Movie> movies = null!)
        : base(directorId){
            FirstName = firstName;
            LastName = lastName;
            Movies = movies ?? new List<Movie>();
    }

    public static Director Create(string firstName, string lastName,ICollection<Movie> movies = null!){
        return new(DirectorId.CreateUnique(), firstName, lastName,movies);
    }

}