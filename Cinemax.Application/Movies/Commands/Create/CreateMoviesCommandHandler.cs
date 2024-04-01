using Cinemax.Application.Actors.Common;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;
using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;
using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.Genre.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;


namespace Cinemax.Application.Movies.Commands.Create;
public class RegisterCommandHandler : IRequestHandler<CreateMovieCommand, MovieResult>
{
    private readonly IMovieRepository _movieRepository; 
    private readonly IActorRepository _actorRepository; 
    private readonly ICountryRepository _countryRepository;
    private readonly IDirectorRepository _directorRepository;
    private readonly IGenreRepository _genreRepository;

    public RegisterCommandHandler(IMovieRepository movieRepository, IActorRepository actorRepository, ICountryRepository countryRepository, IDirectorRepository directorRepository, IGenreRepository genreRepository)
    {
        _movieRepository = movieRepository;  
        _actorRepository = actorRepository;
        _countryRepository = countryRepository;
        _directorRepository = directorRepository;
        _genreRepository = genreRepository;  
    }
    public async Task<MovieResult> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_movieRepository.GetByName(command.Name) is not null){
            throw new Exception("Movie with given name alredy exists");
        }

        List<Actor> actors = new List<Actor>();
        foreach(var actorId in command.Actors)
        {
            if(_actorRepository.GetById(ActorId.Create(new(actorId))) is not Actor existingActor)
                throw new Exception("Actor with id" + actorId + "does not exist");
            actors.Add(existingActor);
        }

        List<Country> countries = new List<Country>();
        foreach(var countryId in command.Countries)
        {
            if(_countryRepository.GetById(CountryId.Create(new(countryId))) is not Country existingCountry)
                throw new Exception("Country with id" + countryId + "does not exist");
            countries.Add(existingCountry);
        }

        List<Director> directors = new List<Director>();
        foreach(var directorId in command.Directors)
        {
            if(_directorRepository.GetById(DirectorId.Create(new(directorId))) is not Director existingDirector)
                throw new Exception("Director with id" + directorId + "does not exist");
            directors.Add(existingDirector);
        }

        List<Genre> genres = new List<Genre>();
        foreach(var genreId in command.Genres)
        {
            if(_genreRepository.GetById(GenreId.Create(new(genreId))) is not Genre existingGenre)
                throw new Exception("Genre with id" + genreId + "does not exist");
            genres.Add(existingGenre);
        }

        Movie movie = Movie.Create(
            command.Name,
            command.Description,
            command.Duration,
            command.Premiere,
            command.IconURL,
            command.TrailerURL,
            command.Summary,
            command.CoverURL,
            command.ImagenURL,
            actors,
            countries,
            directors,
            genres
        );

        _movieRepository.Add(movie);

        return new MovieResult(movie);
    }
}
