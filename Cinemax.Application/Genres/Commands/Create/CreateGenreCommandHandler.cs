using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Genres.Common;
using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.Genres.Commands.Create;
public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreResult>
{
    private readonly IGenreRepository _genreRepository;
    public CreateGenreCommandHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task<GenreResult> Handle(CreateGenreCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_genreRepository.GetByName(command.Name) is not null)
        {
            throw new Exception("Genre with given name alredy exists");
        }

        Genre genre = Genre.Create(
            command.Name,
            new List<Movie>()
        );

        _genreRepository.Insert(genre);

        return new GenreResult(genre);
    }
}
