using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Movies.Common;
using MediatR;

namespace Cinemax.Application.Movies.Queries.Get;
public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieResult>
{
    private readonly IMovieRepository _MovieRepository;

    public GetMovieQueryHandler(IMovieRepository MovieRepository)
    {
        _MovieRepository = MovieRepository;
    }
    public async Task<MovieResult> Handle(GetMovieQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_MovieRepository.GetById(command.MovieId)!);
    }
}
