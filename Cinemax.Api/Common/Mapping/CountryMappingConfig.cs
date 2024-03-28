using Cinemax.Application.Countries.Commands.Create;
using Cinemax.Application.Countries.Common;
using Cinemax.Contracts.Countries;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class CountryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<CountryResult, CountryResponse>()
            .Map(dest => dest.Id, src => src.Country.Id.Value )
            .Map(dest => dest.Name, src => src.Country.Name);
            
        config.NewConfig<CreateCountryRequest, CreateCountryCommand>()
        .Map(dest => dest.Name, src => src.Name);
    }
}