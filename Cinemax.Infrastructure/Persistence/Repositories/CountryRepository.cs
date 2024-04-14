using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class CountryRepository : Repository<Country,CountryId>, ICountryRepository{

    private readonly CinemaxDbContext _cinemaxDbContext;
    public CountryRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public Country? GetByName(string name)
    {
        return _cinemaxDbContext.Countries.SingleOrDefault(c => c.Name == name);
    }
}
