using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.ValueObjects;
using MediatR;

namespace Cinemax.Application.Countries.Queries.Get;
public record GetCountryQuery(
    CountryId CountryId
) : IRequest<CountryResult>;
