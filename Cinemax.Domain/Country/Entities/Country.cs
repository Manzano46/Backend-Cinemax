using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Country.ValueObjects;

namespace Cinemax.Domain.Country.Entities;
public class Country: Entity<CountryId>{
    public string Name {get;set;} = null!;

    #pragma warning disable CS8618
    private Country(){}
    #pragma warning restore CS8618
    private Country(CountryId countryId, string name)
        : base(countryId){
            Name = name;
    }

    public static Country Create(string name){
        return new(CountryId.CreateUnique(), name);
    }

}