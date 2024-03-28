using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.ValueObjects;
using MediatR;

namespace Cinemax.Application.Countries.Commands.Create;
public record CreateCountryCommand(
    string Name
) : IRequest<CountryResult>;

