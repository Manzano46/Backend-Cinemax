using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.Director.ValueObjects;
public sealed class DirectorId : ValueObject
{
    public Guid Value {get;}

    private DirectorId(Guid value){
        Value = value;
    }
    public static DirectorId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static DirectorId Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
