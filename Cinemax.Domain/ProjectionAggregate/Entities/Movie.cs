using Cinemax.Domain.Common.Models;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Domain.ProjectionAggregate.Entities;
public class Movie : Entity<MovieId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public TimeSpan Duration { get; private set; }
    public DateTime Premiere { get; private set; }
    public string IconURL { get; private set; } = null!;
    public string TrailerURL { get; private set; } = null!;
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
    private Movie(MovieId movieId, string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL, string summary, string coverURL, string imagenURL,ICollection<Actor.Entities.Actor> actors, ICollection<Country.Entities.Country> countries, ICollection<Director.Entities.Director> directors, ICollection<Genre.Entities.Genre> genres)
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
        Actors = actors;
        Countries = countries;
        Directors = directors;
        Genres = genres;
    }

    public static Movie Create(string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL,  string summary, string coverURL, string imagenURL, ICollection<Actor.Entities.Actor> actors, ICollection<Country.Entities.Country> countries, ICollection<Director.Entities.Director> directors, ICollection<Genre.Entities.Genre> genres)
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