using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.Entities;
using MediatR;

namespace Cinemax.Application.Countries.Commands.Delete;
public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, CountryResult>
{
    private readonly ICountryRepository _countryRepository; 

    public DeleteCountryCommandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;    
    }
    public async Task<CountryResult> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_countryRepository.GetById(command.Id) is not Country country){
            throw new Exception("Country not found");
        }
        _countryRepository.Delete(command.Id);
        return new CountryResult(country);
    }
}