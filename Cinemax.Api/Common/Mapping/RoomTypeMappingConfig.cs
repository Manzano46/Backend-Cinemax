using Cinemax.Application.RoomTypes.Commands.Create;
using Cinemax.Application.RoomTypes.Commands.Delete;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Application.RoomTypes.Queries.Get;
using Cinemax.Contracts.RoomTypes;
using Cinemax.Domain.RoomType.ValueObjects;
using Mapster;

namespace Cinemax.Api.Common.Mapping;
public class RoomTypeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){
        config.NewConfig<RoomTypeResult, RoomTypeResponse>()
            .Map(dest => dest.Id, src => src.RoomType.Id.Value )
            .Map(dest => dest.Name, src => src.RoomType.Name );
            
        config.NewConfig<CreateRoomTypeRequest, CreateRoomTypeCommand>();

        
        config.NewConfig<DeleteRoomTypeRequest, DeleteRoomTypeCommand>()
            .Map(dest => dest.Id, src => RoomTypeId.Create(new(src.Id)));

        config.NewConfig<GetRoomTypeRequest, GetRoomTypeQuery>()
            .Map(dest => dest.RoomTypeId, src => RoomTypeId.Create(new(src.Id)));
    }
}