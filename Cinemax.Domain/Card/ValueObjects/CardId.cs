using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.Card.ValueObjects;
public sealed class CardId : ValueObject
{
    public long Value {get;}

    private CardId(long value){
        Value = value;
    }
    public static CardId Create(long value){
        return new(value);
    }

    public static CardId Create(string value)
    {
        if (long.TryParse(value, out var id) && value.Length == 16)
        {
            return new CardId(id);
        }
        else
        {
            throw new InvalidCastException($"Invalid card : {value}");
        }
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
