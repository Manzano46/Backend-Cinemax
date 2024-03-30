using Cinemax.Application.Countries.Commands.Create;
using Cinemax.Application.Countries.Common;
using Cinemax.Application.Countries.Queries.Get;
using Cinemax.Contracts.Countries;
using Cinemax.Domain.Country.ValueObjects;
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

        config.NewConfig<DeleteCountryRequest, DeleteCountryCommand>()
            .Map(dest => dest.Id, src => CountryId.Create(new(src.CountryId)));

        config.NewConfig<GetCountryRequest, GetCountryQuery>()
            .Map(dest => dest.CountryId, src => CountryId.Create(new(src.CountryId)));
    }
}