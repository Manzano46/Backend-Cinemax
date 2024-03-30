using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Movies.Commands.Delete;
public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, MovieResult>
{
    private readonly IMovieRepository _MovieRepository;
    public DeleteMovieCommandHandler(IMovieRepository MovieRepository)
    {
        _MovieRepository = MovieRepository;
    }
    public async Task<MovieResult> Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_MovieRepository.GetById(command.MovieId) is not Movie movie)
        {
            throw new Exception("Movie with given name does not exist");
        }

        _MovieRepository.Delete(command.MovieId);

        return new MovieResult(movie);
    }
}
