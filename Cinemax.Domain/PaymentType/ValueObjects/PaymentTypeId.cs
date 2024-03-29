using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.PaymentType.ValueObjects;
public sealed class PaymentTypeId : ValueObject
{
    public Guid Value {get;}

    private PaymentTypeId(Guid value){
        Value = value;
    }
    public static PaymentTypeId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static PaymentTypeId Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
