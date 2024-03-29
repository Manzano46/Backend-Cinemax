using Cinemax.Domain.Common.Models;

namespace Cinemax.Domain.RoomType.ValueObjects;
public sealed class RoomTypeId : ValueObject{
    public Guid Value { get; }

    private RoomTypeId(Guid value)
    {
        this.Value = value;
    }

    public static RoomTypeId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static RoomTypeId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}