using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Actor.ValueObjects;

namespace Cinemax.Domain.Actor.Entities;
public class Actor: Entity<ActorId>{
    public string FirstName {get;set;} = null!;
    public string LastName {get;set;} = null!;

    #pragma warning disable CS8618
    private Actor(){}
    #pragma warning restore CS8618
    private Actor(ActorId actorId, string firstName, string lastName)
        : base(actorId){
            FirstName = firstName;
            LastName = lastName;
    }

    public static Actor Create(string firstName, string lastName){
        return new(ActorId.CreateUnique(), firstName, lastName);
    }

}