using Cinemax.Application.Movies.Common;
using MediatR;

namespace Cinemax.Application.Movies.Queries.Read;
public record ReadMoviesQuery(
    
) : IRequest<IEnumerable<MovieResult>>;
