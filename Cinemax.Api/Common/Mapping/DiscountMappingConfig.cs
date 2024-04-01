using Cinemax.Application.Discounts.Commands.Create;
using Cinemax.Application.Discounts.Common;
using Cinemax.Application.Discounts.Queries.Get;
using Cinemax.Contracts.Discounts;
using Cinemax.Domain.Discount.ValueObjects;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class DiscountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<DiscountResult, DiscountResponse>()
            .Map(dest => dest.Id, src => src.Discount.Id.Value )
            .Map(dest => dest.Name, src => src.Discount.Name)
            .Map(dest => dest.Percentage, src => src.Discount.Percentage);
            
        config.NewConfig<CreateDiscountRequest, CreateDiscountCommand>()
        .Map(dest => dest.Name, src => src.Name)
        .Map(dest => dest.Percentage, src => src.Percentage);

        config.NewConfig<DeleteDiscountRequest, DeleteDiscountCommand>()
            .Map(dest => dest.Id, src => DiscountId.Create(new(src.DiscountId)));

        config.NewConfig<GetDiscountRequest, GetDiscountQuery>()
            .Map(dest => dest.DiscountId, src => DiscountId.Create(new(src.DiscountId)));
    }
}