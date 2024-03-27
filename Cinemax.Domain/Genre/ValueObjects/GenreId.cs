using Cinemax.Domain.Common.Models;

namespace Cinemax.Domain.Genre.ValueObjects;
public sealed class GenreId : ValueObject{
    public Guid Value { get; }

    private GenreId(Guid value)
    {
        this.Value = value;
    }

    public static GenreId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GenreId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}