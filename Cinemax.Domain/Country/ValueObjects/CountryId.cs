using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.Country.ValueObjects;
public sealed class CountryId : ValueObject
{
    public Guid Value {get;}

    private CountryId(Guid value){
        Value = value;
    }
    public static CountryId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static CountryId Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
