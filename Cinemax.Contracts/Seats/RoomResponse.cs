using Cinemax.Contracts.Rooms;

namespace Cinemax.Contracts.Seats
{
    public record SeatResponse
    (
        string Id,
        RoomResponseCore Room
    );
}