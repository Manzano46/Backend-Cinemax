using Cinemax.Contracts.Rooms;

namespace Cinemax.Contracts.RoomTypes
{
    public record ProjectionResponse
    (
        string Id,
        string Name,
        List<CreateRoomRequest> Rooms
    );
}