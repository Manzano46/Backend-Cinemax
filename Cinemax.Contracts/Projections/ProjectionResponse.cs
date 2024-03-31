using Cinemax.Contracts.Movies;
using Cinemax.Contracts.Rooms;

namespace Cinemax.Contracts.Projections
{
    public record ProjectionResponse
    (
        string Id,
        MovieResponseCore Movie,
        RoomResponseCore Room,
        DateTime Date,
        int Price
    );
}