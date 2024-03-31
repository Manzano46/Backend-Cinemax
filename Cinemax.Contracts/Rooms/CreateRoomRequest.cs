namespace Cinemax.Contracts.Rooms
{
    public record CreateRoomRequest
    (
        int Height,
        int Width,
        string Name,
        List<string> RoomTypes
    );
}
