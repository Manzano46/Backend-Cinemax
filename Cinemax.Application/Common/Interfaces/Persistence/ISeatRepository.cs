

using Cinemax.Domain.Seat.Entities;
using Cinemax.Domain.Seat.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface ISeatRepository : IRepository<Seat, SeatId>
    {
    }
}
