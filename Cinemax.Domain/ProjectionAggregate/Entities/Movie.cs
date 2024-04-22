using Cinemax.Domain.Common.Models;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Domain.ProjectionAggregate.Entities;
public class Movie : Entity<MovieId>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TimeSpan Duration { get; set; }
    public DateTime Premiere { get; set; }
    public string IconURL { get; set; } = null!;
    public string TrailerURL { get; set; } = null!;
    public string Summary {get; set;} = null!;
    public string CoverURL {get; set;} = null!;
    public string ImagenURL {get; set;} = null!;
    public virtual ICollection<Actor.Entities.Actor> Actors { get; set; } = new List<Actor.Entities.Actor>();
    public virtual ICollection<Country.Entities.Country> Countries { get; set; } = new List<Country.Entities.Country>();
    public virtual ICollection<Director.Entities.Director> Directors { get; set; } = new List<Director.Entities.Director>();
    public virtual ICollection<Genre.Entities.Genre> Genres { get; set; } = new List<Genre.Entities.Genre>();


#pragma warning disable CS8618
    private Movie() { }
#pragma warning restore CS8618
    private Movie(MovieId movieId, string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL, string summary, string coverURL, string imagenURL,ICollection<Actor.Entities.Actor> actors = null!, ICollection<Country.Entities.Country> countries = null!, ICollection<Director.Entities.Director> directors = null!, ICollection<Genre.Entities.Genre> genres = null!)
        : base(movieId)
    {
        Name = name;
        Description = description;
        Duration = duration;
        Premiere = premiere;
        IconURL = iconURL;
        TrailerURL = trailerURL;
        Summary = summary;
        CoverURL  = coverURL;
        ImagenURL = imagenURL;
        Actors = actors ?? [];
        Countries = countries ?? [];
        Directors = directors ?? [];
        Genres = genres ?? [];
    }

    public static Movie Create(string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL,  string summary, string coverURL, string imagenURL, ICollection<Actor.Entities.Actor> actors = null!, ICollection<Country.Entities.Country> countries = null!, ICollection<Director.Entities.Director> directors = null!, ICollection<Genre.Entities.Genre> genres = null!)
    {

        return new(MovieId.CreateUnique(),
        name,
        description,
        duration,
        premiere,
        iconURL,
        trailerURL,
        summary,
        coverURL,
        imagenURL,
        actors,
        countries,
        directors,
        genres);

    }
}