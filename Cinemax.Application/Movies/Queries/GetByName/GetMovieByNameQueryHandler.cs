using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using MediatR;

namespace Cinemax.Application.Movies.Queries.Get;
public class GetMovieByNameQueryHandler : IRequestHandler<GetMovieByNameQuery, MovieResult>
{
    private readonly IMovieRepository _MovieRepository;

    public GetMovieByNameQueryHandler(IMovieRepository MovieRepository)
    {
        _MovieRepository = MovieRepository;
    }
    public async Task<MovieResult> Handle(GetMovieByNameQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_MovieRepository.GetByName(command.MovieName)!);
    }
}
