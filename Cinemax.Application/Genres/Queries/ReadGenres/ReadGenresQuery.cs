using Cinemax.Application.Genres.Common;
using MediatR;

namespace Cinemax.Application.Genres.Queries.ReadGenres;
public record ReadGenresQuery(

) : IRequest<IEnumerable<GenreResult>>;
