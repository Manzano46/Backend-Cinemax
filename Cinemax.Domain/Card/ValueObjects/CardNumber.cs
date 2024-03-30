using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.Card.ValueObjects;
public sealed class CardNumber : ValueObject
{
    public Guid Value {get;}

    private CardNumber(Guid value){
        Value = value;
    }
    public static CardNumber CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static CardNumber Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
