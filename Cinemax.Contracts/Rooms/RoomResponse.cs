using Cinemax.Contracts.RoomTypes;
using Cinemax.Contracts.Seats;


namespace Cinemax.Contracts.Rooms
{
    public record RoomResponse
    (
        string Id,
        int Height,
        int Width,
        string Name,
        List<RoomTypeResponseCore> RoomTypes,
        List<SeatResponseCore> Seats
    );
}