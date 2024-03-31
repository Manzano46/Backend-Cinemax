using Cinemax.Application.Countries.Common;
using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Domain.Country.ValueObjects;
using MediatR;

namespace Cinemax.Application.Countries.Commands.Create;
public record CreateCountryCommand(
    string Name,
    List<CreateMovieCommand> Movies
) : IRequest<CountryResult>;

