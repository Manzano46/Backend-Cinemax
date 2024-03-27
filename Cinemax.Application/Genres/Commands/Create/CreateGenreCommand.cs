using Cinemax.Application.Genres.Common;
using MediatR;

namespace Cinemax.Application.Genres.Commands.Create;
public record CreateGenreCommand(
    string Name
) : IRequest<GenreResult>;
