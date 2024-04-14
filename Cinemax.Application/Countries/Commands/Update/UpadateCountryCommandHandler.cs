using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Countries.Common;
using Cinemax.Domain.Country.Entities;
using MediatR;
using Cinemax.Domain.Country.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Countrys.Commands.Update;
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, CountryResult>
{
    private readonly ICountryRepository _CountryRepository; 

    public UpdateCountryCommandHandler(ICountryRepository CountryRepository)
    {
        _CountryRepository = CountryRepository;    
    }
    public async Task<CountryResult> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var countryId = CountryId.Create(new (command.Id));
        var Country = _CountryRepository.GetById(countryId);

        if (Country is null)
        {
            throw new Exception("Country with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Country);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Country", ex);
        }
        
        _CountryRepository.Update(Country);

        return new CountryResult(Country);
    }
}