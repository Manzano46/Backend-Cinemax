using Cinemax.Application.Discounts.Commands.Create;
using Cinemax.Application.Discounts.Common;
using Cinemax.Contracts.Discounts;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class DiscountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<DiscountResult, DiscountResponse>()
            .Map(dest => dest.Id, src => src.Discount.Id.Value )
            .Map(dest => dest.Name, src => src.Discount.Name);
            
        config.NewConfig<CreateDiscountRequest, CreateDiscountCommand>()
        .Map(dest => dest.Name, src => src.Name);
    }
}