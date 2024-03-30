using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Countries.Common;
using MediatR;

namespace Cinemax.Application.Countries.Queries.Get;
public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryResult>
{
    private readonly ICountryRepository _CountryRepository;

    public GetCountryQueryHandler(ICountryRepository CountryRepository)
    {
        _CountryRepository = CountryRepository;
    }
    public async Task<CountryResult> Handle(GetCountryQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_CountryRepository.GetById(command.CountryId)!);
    }
}
