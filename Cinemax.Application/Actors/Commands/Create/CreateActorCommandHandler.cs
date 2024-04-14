using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Actors.Commands.Create;
public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, ActorResult>
{
    private readonly IActorRepository _actorRepository; 
    private readonly IMovieRepository _MovieRepository;

    public CreateActorCommandHandler(IActorRepository actorRepository,IMovieRepository movieRepository)
    {
        _actorRepository = actorRepository;  
        _MovieRepository = movieRepository;   
    }
    public async Task<ActorResult> Handle(CreateActorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_actorRepository.GetByName(command.Firstname,command.Lastname) is not null){
            throw new Exception("Actor with given name alredy exists");
        }

        List<Movie> movies = new();

        command.Movies.ForEach(movie =>
        {
            Movie existingMovie = _MovieRepository.GetByName(movie.Name)!;
            if (existingMovie is null)
            {
                throw new Exception($"Movies '{movie.Name}' does not exist in the database");
            }
            movies.Add(existingMovie);
        });

        Actor actor = Actor.Create(
            command.Firstname,
            command.Lastname,
            movies
        );

        _actorRepository.Insert(actor);

        return new ActorResult(actor);
    }

}
