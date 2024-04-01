using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Genre.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Domain.Genre.Entities
{
    public class Genre : Entity<GenreId>
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<Movie> Movies { get; set; } = null!;
    

        #pragma warning disable CS8618
        private Genre() { } 
        #pragma warning restore CS8618

        private Genre(GenreId genreId, string name,ICollection<Movie> movies = null!)
            : base(genreId)
        {
            Name = name;
            Movies = movies;
        }

        public static Genre Create(string name,ICollection<Movie> movies = null!)
        {
            return new Genre(GenreId.CreateUnique(), name,movies);
        }
    }
}
