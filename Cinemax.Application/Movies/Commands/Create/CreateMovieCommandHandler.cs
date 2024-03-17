using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using Cinemax.Domain.Entities;
using MediatR;

namespace Cinemax.Application.Movies.Commands.Create;
public class RegisterCommandHandler : IRequestHandler<CreateMovieCommand, MovieResult>
{
    private readonly IMovieRepository _movieRepository; 

    public RegisterCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;    
    }
    public async Task<MovieResult> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_movieRepository.GetMovieByName(command.Name) is not null){
            throw new Exception("Movie with given name alredy exists");
        }

        Movie movie = new Movie{
            Name = command.Name,
            Description = command.Description,
            Duration = command.Duration,
            Premiere = command.Premiere,
            IconURL = command.IconURL,
            TrailerURL = command.TrailerURL,
        };

        _movieRepository.Add(movie);

        return new MovieResult(movie);
    }
}
