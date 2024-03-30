namespace Cinemax.Contracts.Rooms
{
    public record CreateRoomRequest
    (
        int Height,
        int Width,
        List<string> RoomTypes
    );
}
