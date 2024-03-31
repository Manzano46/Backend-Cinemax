using Cinemax.Domain.Common.Models;

namespace Cinemax.Domain.Seat.ValueObjects;
public sealed class SeatId : ValueObject{
    public Guid Value { get; }

    private SeatId(Guid value)
    {
        this.Value = value;
    }

    public static SeatId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static SeatId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}