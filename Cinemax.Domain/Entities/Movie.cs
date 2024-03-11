namespace Cinemax.Domain.Entities;
public class Movie{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public TimeSpan Duration {get; set;}
    public DateTime Premiere{get; set;}
    public string IconURL{get; set;} = null!;
    public string TrailerURL{get; set;} = null!;
}