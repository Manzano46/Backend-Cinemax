using Cinemax.Domain.Common.Models;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Domain.ProjectionAggregate.Entities;
public sealed class Movie : Entity<MovieId>
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public TimeSpan Duration { get; private set; }
    public DateTime Premiere { get; private set; }
    public string IconURL { get; private set; } = null!;
    public string TrailerURL { get; private set; } = null!;

#pragma warning disable CS8618
    private Movie() { }
#pragma warning restore CS8618
    private Movie(MovieId movieId, string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL)
        : base(movieId)
    {
        Name = name;
        Description = description;
        Duration = duration;
        Premiere = premiere;
        IconURL = iconURL;
        TrailerURL = trailerURL;
    }

    public static Movie Create(string name, string description, TimeSpan duration, DateTime premiere, string iconURL, string trailerURL)
    {

        return new(MovieId.CreateUnique(),
        name,
        description,
        duration,
        premiere,
        iconURL,
        trailerURL);

    }
}