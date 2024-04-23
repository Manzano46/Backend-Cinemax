using Cinemax.Application.PaymentTypes.Commands.Create;
using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Contracts.PaymentTypes;
using Cinemax.Domain.PaymentType.Entities;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class PaymentTypeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<PaymentTypeResult, PaymentTypeResponse>()
            .Map(dest => dest.Id, src => src.PaymentType.Id.Value )
            .Map(dest => dest.Name, src => src.PaymentType.Name);
            
        config.NewConfig<CreatePaymentTypeRequest, CreatePaymentTypeCommand>()
        .Map(dest => dest.Name, src => src.Name);

        config.NewConfig<PaymentType, PaymentTypeResponse>()
            .Map(dest => dest.Id, src => src.Id.Value )
            .Map(dest => dest.Name, src => src.Name);
           
    }
}