using Cinemax.Contracts.Movies;
using Cinemax.Contracts.Rooms;

namespace Cinemax.Contracts.Projections
{
    public record ProjectionResponse
    (
        string Id,
        string MovieId,
        string RoomId,
        DateTime Date,
        int Price
    );
}