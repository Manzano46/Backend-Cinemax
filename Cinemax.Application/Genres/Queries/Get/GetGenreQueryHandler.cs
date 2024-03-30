using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Genres.Common;
using MediatR;

namespace Cinemax.Application.Genres.Queries.Get;
public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, GenreResult>
{
    private readonly IGenreRepository _GenreRepository;

    public GetGenreQueryHandler(IGenreRepository GenreRepository)
    {
        _GenreRepository = GenreRepository;
    }
    public async Task<GenreResult> Handle(GetGenreQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_GenreRepository.GetById(command.GenreId)!);
    }
}
