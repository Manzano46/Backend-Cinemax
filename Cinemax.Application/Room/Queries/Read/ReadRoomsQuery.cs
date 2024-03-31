using Cinemax.Application.Rooms.Common;
using MediatR;

namespace Cinemax.Application.Rooms.Queries.Read;
public record ReadRoomQuery(

) : IRequest<IEnumerable<RoomResult>>;
