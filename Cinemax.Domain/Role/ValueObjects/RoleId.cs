using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.Role.ValueObjects;
public sealed class RoleId : ValueObject
{
    public Guid Value {get;}

    private RoleId(Guid value){
        Value = value;
    }
    public static RoleId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static RoleId Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
