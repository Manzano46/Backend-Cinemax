using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Seat.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;

namespace Cinemax.Domain.Seat.Entities
{
    public class Seat : Entity<SeatId>
    {
        public RoomId RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int Row {get; set;}
        public int Colum {get; set;}
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        #pragma warning disable CS8618
        private Seat() { } 
        #pragma warning restore CS8618

        private Seat(SeatId Id, RoomId roomId, Room room, int row, int colum)
            : base(Id)
        {
            RoomId = roomId;
            Room = room;
            Row = row;
            Colum = colum;
        }

        public static Seat Create(RoomId roomId, Room room, int row, int colum)
        {
            return new(SeatId.CreateUnique(), roomId, room, row, colum);
        }
    }
}
