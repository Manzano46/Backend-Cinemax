using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Countries.Common;
using Cinemax.Application.Countries.Queries.Read;
using MediatR;

namespace Cinemax.Application.Countries.Query.Read;
public class ReadCountriesQueryHandler : IRequestHandler<ReadCountriesQuery, IEnumerable<CountryResult>>
{
    private readonly ICountryRepository _countryRepository; 

    public ReadCountriesQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;    
    }
    public async Task<IEnumerable<CountryResult>> Handle(ReadCountriesQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _countryRepository.GetAll().Select(x => new CountryResult(x));
    }
}
