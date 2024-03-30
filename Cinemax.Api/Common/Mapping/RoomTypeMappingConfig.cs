using Cinemax.Application.RoomTypes.Commands.Create;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Contracts.RoomTypes;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class RoomTypeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<RoomTypeResult, ProjectionResponse>()
            .Map(dest => dest.Id, src => src.RoomType.Id.Value )
            .Map(dest => dest.Name, src => src.RoomType.Name )
            .Map(dest => dest.Rooms, src => src.RoomType.Rooms);
            
        config.NewConfig<CreateRoomTypeRequest, CreateRoomTypeCommand>();
    }
}