using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.Actor.ValueObjects;
public sealed class ActorId : ValueObject
{
    public Guid Value {get;}

    private ActorId(Guid value){
        Value = value;
    }
    public static ActorId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static ActorId Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
