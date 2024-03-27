using Cinemax.Application.Genres.Common;
using MediatR;

namespace Cinemax.Application.Genres.Commands.Delete;
public record DeleteGenreCommand(
    string Name
) : IRequest<GenreResult>;
