using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.ProjectionAggregate.ValueObjects;
public sealed class RoomId : ValueObject
{
    public Guid Value {get;}

    private RoomId(Guid value){
        Value = value;
    }
    public static RoomId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static RoomId Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
