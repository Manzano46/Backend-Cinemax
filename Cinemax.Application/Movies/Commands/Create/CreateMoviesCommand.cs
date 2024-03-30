using Cinemax.Application.Movies.Common;
using MediatR;

namespace Cinemax.Application.Movies.Commands.Create;
public record CreateMovieCommand(
    string Name,
    string Description,
    TimeSpan Duration,
    DateTime Premiere,
    string IconURL,
    string TrailerURL,
    List<string> Actors,
    List<string> Countries,
    List<string> Directors,
    List<string> Genres
) : IRequest<MovieResult>;
