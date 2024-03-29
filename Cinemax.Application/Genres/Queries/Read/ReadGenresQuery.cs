using Cinemax.Application.Genres.Common;
using MediatR;

namespace Cinemax.Application.Genres.Queries.Read;
public record ReadGenresQuery(

) : IRequest<IEnumerable<GenreResult>>;
