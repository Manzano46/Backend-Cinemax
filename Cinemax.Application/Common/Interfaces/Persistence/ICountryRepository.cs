using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface ICountryRepository{
    Country? GetByName(string name);
    Country? GetById(CountryId countryId);
    void Add(Country country);
    void Delete(CountryId country);
    IEnumerable<Country> GetAllCountries();
}
