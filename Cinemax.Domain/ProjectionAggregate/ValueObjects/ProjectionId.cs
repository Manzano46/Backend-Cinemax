using Cinemax.Domain.Common.Models;

namespace Cinemax.Domain.ProjectionAggregate.ValueObjects
{
    public class ProjectionId : ValueObject
    {
        public Guid Value { get; }

        private ProjectionId(Guid value)
        {
            Value = value;
        }
        public static ProjectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static ProjectionId Create(Guid value)
        {
            return new(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
