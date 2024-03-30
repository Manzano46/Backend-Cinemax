using Cinemax.Application.Genres.Common;
using Cinemax.Domain.Genre.ValueObjects;
using MediatR;

namespace Cinemax.Application.Genres.Commands.Delete;
public record DeleteGenreCommand(
    GenreId GenreId
) : IRequest<GenreResult>;
