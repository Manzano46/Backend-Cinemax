using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Genres.Common;
using MediatR;

namespace Cinemax.Application.Genres.Queries.Read;
public class ReadGenresQueryHandler : IRequestHandler<ReadGenresQuery, IEnumerable<GenreResult>>
{
    private readonly IGenreRepository _genreRepository;

    public ReadGenresQueryHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<IEnumerable<GenreResult>> Handle(ReadGenresQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _genreRepository.GetAll().Select(x => new GenreResult(x));
    }
}
