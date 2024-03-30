using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Director.ValueObjects;

namespace Cinemax.Domain.Director.Entities;
public class Director: Entity<DirectorId>{
    public string FirstName {get;set;} = null!;
    public string LastName {get;set;} = null!;

    #pragma warning disable CS8618
    private Director(){}
    #pragma warning restore CS8618
    private Director(DirectorId directorId, string firstName, string lastName)
        : base(directorId){
            FirstName = firstName;
            LastName = lastName;
    }

    public static Director Create(string firstName, string lastName){
        return new(DirectorId.CreateUnique(), firstName, lastName);
    }

}