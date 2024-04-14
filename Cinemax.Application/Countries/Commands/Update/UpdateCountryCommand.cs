using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdateCountryCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<CountryResult>;
