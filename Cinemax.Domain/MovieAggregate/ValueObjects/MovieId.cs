using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.MovieAggregate.ValueObjects;
public sealed class MovieId : ValueObject
{
    public Guid Value {get;}

    private MovieId(Guid value){
        Value = value;
    }
    public static MovieId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
