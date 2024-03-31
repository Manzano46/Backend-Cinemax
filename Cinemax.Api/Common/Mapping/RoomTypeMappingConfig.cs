using Cinemax.Application.RoomTypes.Commands.Create;
using Cinemax.Application.RoomTypes.Commands.Delete;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Application.RoomTypes.Queries.Get;
using Cinemax.Contracts.Rooms;
using Cinemax.Contracts.RoomTypes;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.RoomType.ValueObjects;
using Mapster;
using MapsterMapper;

namespace Cinemax.Api.Common.Mapping;
public class RoomTypeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<RoomTypeResult, RoomTypeResponse>()
            .Map(dest => dest.Id, src => src.RoomType.Id.Value )
            .Map(dest => dest.Name, src => src.RoomType.Name)
            .Map(dest => dest.Rooms, src => src.RoomType.Rooms.Select(r => new RoomResponseCore(r.Id.Value.ToString(), r.Height, r.Width)) );
            
        config.NewConfig<CreateRoomTypeRequest, CreateRoomTypeCommand>();
        
        config.NewConfig<DeleteRoomTypeRequest, DeleteRoomTypeCommand>()
            .Map(dest => dest.Id, src => RoomTypeId.Create(new(src.Id)));

        config.NewConfig<GetRoomTypeRequest, GetRoomTypeQuery>()
            .Map(dest => dest.RoomTypeId, src => RoomTypeId.Create(new(src.Id)));

        config.NewConfig<RoomType, RoomTypeResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.Name, src => src.Name);  
    }
}