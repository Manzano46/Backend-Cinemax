using Cinemax.Contracts.RoomTypes;


namespace Cinemax.Contracts.Rooms
{
    public record RoomResponse
    (
        string Id,
        int Height,
        int Width,
        List<RoomTypeResponse> RoomTypes
    );
}