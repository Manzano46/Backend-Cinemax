using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Genres.Common;
using Cinemax.Domain.Genre.Entities;
using MediatR;

namespace Cinemax.Application.Genres.Commands.Delete;
public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, GenreResult>
{
    private readonly IGenreRepository _genreRepository;
    public DeleteGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<GenreResult> Handle(DeleteGenreCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_genreRepository.GetByName(command.Name) is not Genre genre)
        {
            throw new Exception("Genre with given name does not exist");
        }

        _genreRepository.Delete(command.Name);

        return new GenreResult(genre);
    }
}
