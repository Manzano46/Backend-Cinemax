using Cinemax.Contracts.Rooms;

namespace Cinemax.Contracts.Seats
{
    public record SeatResponse
    (
        string Id,
        int Row,
        int Colum,
        RoomResponseCore Room
    );
}