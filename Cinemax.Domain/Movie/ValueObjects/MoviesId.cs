using Cinemax.Domain.Common.Models;
namespace Cinemax.Domain.Movie.ValueObjects;
public sealed class MoviesId : ValueObject
{
    public Guid Value {get;}

    private MoviesId(Guid value){
        Value = value;
    }
    public static MoviesId CreateUnique(){
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
