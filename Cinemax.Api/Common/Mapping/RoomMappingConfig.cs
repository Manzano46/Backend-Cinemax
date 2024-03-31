using Cinemax.Application.Rooms.Commands.Create;
using Cinemax.Application.Rooms.Commands.Delete;
using Cinemax.Application.Rooms.Common;
using Cinemax.Application.Rooms.Queries.Get;
using Cinemax.Contracts.Rooms;
using Cinemax.Contracts.RoomTypes;
using Cinemax.Contracts.Seats;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.RoomType.ValueObjects;
using Cinemax.Domain.Seat.Entities;
using Mapster;
using MapsterMapper;

namespace Cinemax.Api.Common.Mapping;
public class RoomMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config){

        config.NewConfig<RoomResult, RoomResponse>()
            .Map(dest => dest.Id, src => src.Room.Id.Value)
            .Map(dest => dest.Height, src => src.Room.Height)
            .Map(dest => dest.Width, src => src.Room.Width)
            .Map(dest => dest.Name, src => src.Room.Name)
            .Map(dest => dest.RoomTypes, src => src.Room.RoomTypes)
            .Map(dest => dest.Seats, src => src.Room.Seats);
        
        config.NewConfig<CreateRoomRequest, CreateRoomCommand>()
            .Map(dest => dest.RoomTypesId, src => src.RoomTypes.Select(id => RoomTypeId.Create( new(id) ) ))
            .Map(dest => dest, src => src);

        config.NewConfig<DeleteRoomRequest, DeleteRoomCommand>()
            .Map(dest => dest.Id, src => RoomId.Create(new(src.Id)));

        config.NewConfig<GetRoomRequest, GetRoomQuery>()
            .Map(dest => dest.RoomId, src => RoomId.Create(new(src.Id)));
        
        config.NewConfig<Room, RoomResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value.ToString())
            .Map(dest => dest.Height, src => src.Height)
            .Map(dest => dest.Width, src => src.Width)
            .Map(dest => dest.Name, src => src.Name);

        config.NewConfig<Seat, SeatResponseCore>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
