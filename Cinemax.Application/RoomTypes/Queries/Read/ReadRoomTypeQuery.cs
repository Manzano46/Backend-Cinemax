using Cinemax.Application.RoomTypes.Common;
using MediatR;

namespace Cinemax.Application.RoomTypes.Queries.Read;
public record ReadRoomTypesQuery(

) : IRequest<IEnumerable<RoomTypeResult>>;
