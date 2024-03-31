using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Domain.Seat.Entities
{
    public class Seat : Entity<SeatId>
    {
        public RoomId RoomId { get; set; }
        public virtual Room Room { get; set; }

        #pragma warning disable CS8618
        private Seat() { } 
        #pragma warning restore CS8618

        private Seat(SeatId Id, RoomId roomId, Room room)
            : base(Id)
        {
            RoomId = roomId;
            Room = room;
        }

        public static Seat Create(RoomId roomId, Room room)
        {
            return new(SeatId.CreateUnique(), roomId, room );
        }
    }
}
