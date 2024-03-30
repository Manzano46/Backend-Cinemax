using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.ProjectionAggregate.ValueObjects;
public sealed class MovieId : ValueObject
{
    public Guid Value { get; }

    private MovieId(Guid value)
    {
        Value = value;
    }
    public static MovieId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static MovieId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
