using Cinemax.Application.Rooms.Commands.Create;
using Cinemax.Application.Rooms.Commands.Delete;
using Cinemax.Application.Rooms.Common;
using Cinemax.Application.Rooms.Queries.Get;
using Cinemax.Contracts.Rooms;
using Cinemax.Contracts.RoomTypes;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.RoomType.ValueObjects;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class RoomMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<RoomResult, RoomResponse>()
            .Map(dest => dest.Id, src => src.Room.Id.Value)
            .Map(dest => dest.Height, src => src.Room.Height)
            .Map(dest => dest.Width, src => src.Room.Width)
            .Map(dest => dest.RoomTypes, src => src.Room.RoomTypes.Select(x => new RoomTypeResponse(x.Id.Value.ToString(), x.Name)));
            
        config.NewConfig<CreateRoomRequest, CreateRoomCommand>()
            .Map(dest => dest.RoomTypesId, src => src.RoomTypes.Select(id => RoomTypeId.Create( new(id) ) ))
            .Map(dest => dest, src => src);

        config.NewConfig<DeleteRoomRequest, DeleteRoomCommand>()
            .Map(dest => dest.Id, src => RoomId.Create(new(src.Id)));

        config.NewConfig<GetRoomRequest, GetRoomQuery>()
            .Map(dest => dest.RoomId, src => RoomId.Create(new(src.Id)));
    }
}
