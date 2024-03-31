

using Cinemax.Domain.Seat.Entities;
using Cinemax.Domain.Seat.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence
{
    public interface ISeatRepository
    {
        Seat? GetById(SeatId id);       
        void Add(Seat Seat);
        void Delete(SeatId id);
        IEnumerable<Seat> GetAll();
    }
}
