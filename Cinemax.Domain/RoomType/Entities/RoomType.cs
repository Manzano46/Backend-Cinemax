using Cinemax.Domain.Common.Models;
using Cinemax.Domain.RoomType.ValueObjects;
using Cinemax.Domain.Room.Entities;

namespace Cinemax.Domain.RoomType.Entities
{
    public class RoomType : Entity<RoomTypeId>
    {
        public string Name { get; set; } = null!;
        public virtual ICollection<Room.Entities.Room> Rooms { get; set; } = new List<Room.Entities.Room>();

        #pragma warning disable CS8618
        private RoomType() { } 
        #pragma warning restore CS8618

        private RoomType(RoomTypeId RoomTypeId, string name,  ICollection<Room.Entities.Room> rooms = null!)
            : base(RoomTypeId)
        {
            Name = name;
            Rooms = rooms ?? new List<Room.Entities.Room>();
        }

        public static RoomType Create(string name, ICollection<Room.Entities.Room> rooms = null!)
        {
            return new RoomType(RoomTypeId.CreateUnique(), name, rooms);
        }
    }
}
