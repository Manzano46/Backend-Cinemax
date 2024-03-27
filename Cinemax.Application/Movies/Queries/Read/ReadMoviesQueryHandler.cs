using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using Cinemax.Application.Movies.Queries.Read;
using MediatR;

namespace Cinemax.Application.Movies.Query.Read;
public class ReadMoviesQueryHandler : IRequestHandler<ReadMoviesQuery, IEnumerable<MovieResult>>
{
    private readonly IMovieRepository _movieRepository; 

    public ReadMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;    
    }
    public async Task<IEnumerable<MovieResult>> Handle(ReadMoviesQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _movieRepository.GetAllMovies().Select(x => new MovieResult(x));
    }
}
