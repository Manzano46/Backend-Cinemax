using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Genre.ValueObjects;

namespace Cinemax.Domain.Genre.Entities
{
    public class Genre : Entity<GenreId>
    {
        public string Name { get; set; } = null!;

        #pragma warning disable CS8618
        private Genre() { } 
        #pragma warning restore CS8618

        private Genre(GenreId genreId, string name)
            : base(genreId)
        {
            Name = name;
        }

        public static Genre Create(string name)
        {
            return new Genre(GenreId.CreateUnique(), name);
        }
    }
}
