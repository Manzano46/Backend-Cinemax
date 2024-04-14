using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using MediatR;
using Newtonsoft.Json;

namespace Cinemax.Application.Movies.Commands.Update;
public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, MovieResult>
{
    private readonly IMovieRepository _MovieRepository; 

    public UpdateMovieCommandHandler(IMovieRepository MovieRepository)
    {
        _MovieRepository = MovieRepository;    
    }
    public async Task<MovieResult> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var movieId = MovieId.Create(new (command.Id));
        var Movie = _MovieRepository.GetById(movieId);

        if (Movie is null)
        {
            throw new Exception("Movie with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Movie);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Movie", ex);
        }
        
        _MovieRepository.Update(Movie);

        return new MovieResult(Movie);
    }
}