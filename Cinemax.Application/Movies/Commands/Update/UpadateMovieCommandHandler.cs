using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using Cinemax.Domain.Actor.ValueObjects;
using Cinemax.Domain.Country.ValueObjects;
using Cinemax.Domain.Director.ValueObjects;
using Cinemax.Domain.Genre.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

namespace Cinemax.Application.Movies.Commands.Update;
public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieResult>
{
    private readonly IMovieRepository _MovieRepository; 
    private readonly IGenreRepository _GenreRepository;
    private readonly ICountryRepository _CountryRepository;
    private readonly IActorRepository _ActorRepository;
    private readonly IDirectorRepository _DirectorRepository;
    public UpdateMovieCommandHandler(IMovieRepository MovieRepository, IGenreRepository GenreRepository, ICountryRepository CountryRepository, IDirectorRepository DirectorRepository, IActorRepository ActorRepository)
    {
        _MovieRepository = MovieRepository;    
        _GenreRepository = GenreRepository;
        _CountryRepository = CountryRepository;
        _DirectorRepository = DirectorRepository;
        _ActorRepository = ActorRepository;
    }
    public async Task<MovieResult> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var movieId = MovieId.Create(new (command.Id));
        var movie = _MovieRepository.GetById(movieId);

        if (movie is null)
        {
            throw new Exception("Movie with given Id does not exist");
        }

        try
        {
            var filteredPatchDoc = new JsonPatchDocument<Movie>(command.patchDoc.Operations.Where(op => op.path != "/genres" && op.path != "/countries" && op.path != "/directors" && op.path != "/actors").ToList(), command.patchDoc.ContractResolver);

            filteredPatchDoc.ApplyTo(movie);

            foreach (var operation in command.patchDoc.Operations.Where(op => op.path == "/genres"))
            {
                var genreId = operation.value.ToString();
                var genre =  _GenreRepository.GetById(GenreId.Create(new(genreId)));
                if (genre is null)
                {
                    throw new Exception($"Genre with id {genreId} not found");
                }

                if (operation.op == "add")
                {
                    movie.Genres.Add(genre);
                }
                else if (operation.op == "remove")
                {
                    movie.Genres.Remove(genre);
                }
            }

            foreach (var operation in command.patchDoc.Operations.Where(op => op.path == "/countries"))
            {
                var countryId = operation.value.ToString();
                var country = _CountryRepository.GetById(CountryId.Create(new(countryId)));
                if (country is null)
                {
                    throw new Exception($"Country with id {countryId} not found");
                }

                if (operation.op == "add")
                {
                    movie.Countries.Add(country);
                }
                else if (operation.op == "remove")
                {
                    movie.Countries.Remove(country);
                }
            }

            foreach (var operation in command.patchDoc.Operations.Where(op => op.path == "/directors"))
            {
                var directorId = operation.value.ToString();
                var director = _DirectorRepository.GetById(DirectorId.Create(new(directorId)));
                if (director is null)
                {
                    throw new Exception($"Director with id {directorId} not found");
                }

                if (operation.op == "add")
                {
                    movie.Directors.Add(director);
                }
                else if (operation.op == "remove")
                {
                    movie.Directors.Remove(director);
                }
            }

            foreach (var operation in command.patchDoc.Operations.Where(op => op.path == "/actors"))
            {
                var actorId = operation.value.ToString();
                var actor = _ActorRepository.GetById(ActorId.Create(new(actorId)));
                if (actor is null)
                {
                    throw new Exception($"Actor with id {actorId} not found");
                }

                if (operation.op == "add")
                {
                    movie.Actors.Add(actor);
                }
                else if (operation.op == "remove")
                {
                    movie.Actors.Remove(actor);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Movie", ex);
        }
        
        _MovieRepository.Update(movie);

        return new MovieResult(movie);
    }
}