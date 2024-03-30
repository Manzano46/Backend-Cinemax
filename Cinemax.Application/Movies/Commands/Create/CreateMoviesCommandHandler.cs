using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using Cinemax.Domain.MovieAggregate.Entities;
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
        if(_movieRepository.GetByName(command.Name) is not null){
            throw new Exception("Movie with given name alredy exists");
        }

        Movie movie = Movie.Create(
            command.Name,
            command.Description,
            command.Duration,
            command.Premiere,
            command.IconURL,
            command.TrailerURL
        );

        _movieRepository.Add(movie);

        return new MovieResult(movie);
    }
}
