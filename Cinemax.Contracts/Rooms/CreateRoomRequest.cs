using Cinemax.Contracts.RoomTypes;

namespace Cinemax.Contracts.Rooms
{
    public record CreateRoomRequest
    (
        int Height,
        int Width,
        List<CreateProjectionRequest> RoomTypes
    );
}
