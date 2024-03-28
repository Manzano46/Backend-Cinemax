using Cinemax.Application.Movies.Common;
using MediatR;

namespace Cinemax.Application.Movies.Commands.Create;
public record CreateMovieCommand(
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL
) : IRequest<MovieResult>;
