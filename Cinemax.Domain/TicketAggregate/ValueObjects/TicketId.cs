using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.TicketAggregate.ValueObjects;
public sealed class TicketId : ValueObject
{
    public Guid Value {get;}

    private TicketId(Guid value){
        Value = value;
    }
    public static TicketId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public static TicketId Create(Guid value){
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
