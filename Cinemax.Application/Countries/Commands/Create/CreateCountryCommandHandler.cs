using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.Entities;
using MediatR;

namespace Cinemax.Application.Countries.Commands.Create;
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryResult>
{
    private readonly ICountryRepository _countryRepository; 

    public CreateCountryCommandHandler(ICountryRepository CountryRepository)
    {
        _countryRepository = CountryRepository;    
    }
    public async Task<CountryResult> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_countryRepository.GetByName(command.Name) is not null){
            throw new Exception("Country with given name alredy exists");
        }

        Country country = Country.Create(
            command.Name
        );

        _countryRepository.Add(country);

        return new CountryResult(country);
    }

}
