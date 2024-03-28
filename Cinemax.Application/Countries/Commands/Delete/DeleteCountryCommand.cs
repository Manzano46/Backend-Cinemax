using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.ValueObjects;
using MediatR;

public record DeleteCountryCommand(CountryId Id) : IRequest<CountryResult>;
