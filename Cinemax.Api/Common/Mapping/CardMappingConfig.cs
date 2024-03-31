using Cinemax.Application.Cards.Commands.Create;
using Cinemax.Application.Cards.Common;
using Cinemax.Contracts.Cards;
using Cinemax.Domain.Card.ValueObjects;
using Cinemax.Domain.User.ValueObjects;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class CardMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<CardResult, CardResponse>()
            .Map(dest => dest.Id, src => src.Card.Id.Value);

        config.NewConfig<CreateCardRequest, CreateCardCommand>()
            .Map(dest => dest.Id, src =>CardId.Create(src.Id.ToString()));
            //.Map(dest => dest.User, src => UserId.Create(new Guid(src.UserId)));
    }
}