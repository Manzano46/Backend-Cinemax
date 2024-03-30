using Cinemax.Application.Cards.Commands.Create;
using Cinemax.Application.Cards.Common;
using Cinemax.Contracts.Cards;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class CardMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<CardResult, CardResponse>()
            .Map(dest => dest.Number, src => src.Card.Number.Value);

        config.NewConfig<CreateCardRequest, CreateCardCommand>()
        .Map(dest => dest.Number, src => src.Number);
    }
}