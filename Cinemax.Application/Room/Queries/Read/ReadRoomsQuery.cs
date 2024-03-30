using Cinemax.Application.Rooms.Common;
using MediatR;

namespace Cinemax.Application.Rooms.Queries.Read;
public record ReadProjectionQuery(

) : IRequest<IEnumerable<RoomResult>>;
