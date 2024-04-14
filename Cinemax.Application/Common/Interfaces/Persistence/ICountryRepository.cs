using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface ICountryRepository : IRepository<Country,CountryId>{
    Country? GetByName(string name);
}
