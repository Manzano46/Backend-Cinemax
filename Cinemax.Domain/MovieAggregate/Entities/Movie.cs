using Cinemax.Domain.Common.Models;
using Cinemax.Domain.MovieAggregate.ValueObjects;

namespace Cinemax.Domain.MovieAggregate.Entities;
public sealed class Movie: Entity<MovieId>{
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public TimeSpan Duration {get; set;}
    public DateTime Premiere{get; set;}
    public string IconURL{get; set;} = null!;
    public string TrailerURL{get; set;} = null!;

    private Movie(MovieId movieId, string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL)
        : base(movieId){
            Name = name;
            Description = description;
            Duration = duration;
            Premiere = premiere;
            IconURL = iconURL;
            TrailerURL = trailerURL;
    }

    public static Movie Create(string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL){

            return new(MovieId.CreateUnique() ,
            name,
            description,
            duration,
            premiere,
            iconURL,
            trailerURL);

    }
}