using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Country.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Domain.Country.Entities;
public class Country: Entity<CountryId>{
    public string Name {get;set;} = null!;
    public virtual ICollection<Movie> Movies { get; set; } = null!;

    #pragma warning disable CS8618
    private Country(){}
    #pragma warning restore CS8618
    private Country(CountryId countryId, string name,ICollection<Movie> movies)
        : base(countryId){
            Name = name;
            Movies = movies ?? new List<Movie>();
    }

    public static Country Create(string name, ICollection<Movie> movies = null!){
        return new(CountryId.CreateUnique(), name, movies);
    }

}