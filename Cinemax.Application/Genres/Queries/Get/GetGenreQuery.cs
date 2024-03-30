using Cinemax.Application.Genres.Common;
using Cinemax.Domain.Genre.ValueObjects;
using MediatR;

namespace Cinemax.Application.Genres.Queries.Get;
public record GetGenreQuery(
    GenreId GenreId
) : IRequest<GenreResult>;
