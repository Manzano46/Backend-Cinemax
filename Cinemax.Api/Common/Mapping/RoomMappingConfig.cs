/*using Cinemax.Application.Rooms.Commands.Create;
using Cinemax.Application.Rooms.Common;
using Cinemax.Contracts.Rooms;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class RoomMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<RoomResult, RoomResponse>()
            .Map(dest => dest.Id, src => src.Room.Id.Value )
            .Map(dest => dest.Name, src => src.Room.Name );
            
        config.NewConfig<CreateRoomRequest, CreateRoomCommand>();
    }
}
*/