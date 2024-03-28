using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class CountryRepository : ICountryRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public CountryRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Country country)
    {
        _cinemaxDbContext.Countries.Add(country);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Country> GetAllCountries()
    {
        return _cinemaxDbContext.Countries;
    }

    public Country? GetByName(string name)
    {
        return _cinemaxDbContext.Countries.SingleOrDefault(m => m.Name == name);
    }
    
       public Country? GetById(CountryId CountryId)
    {
        return _cinemaxDbContext.Countries.SingleOrDefault(m => m.Id == CountryId);
    }
    
    public void Delete(CountryId id)
    {
        var country = _cinemaxDbContext.Countries.SingleOrDefault(m => m.Id == id);
        if (country is not null)
        {
            _cinemaxDbContext.Countries.Remove(country);
            _cinemaxDbContext.SaveChanges();
        }
    }


}
