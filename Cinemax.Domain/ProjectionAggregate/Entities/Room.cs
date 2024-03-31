using Cinemax.Domain.Common.Models;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;

namespace Cinemax.Domain.ProjectionAggregate.Entities;
public class Room: Entity<RoomId>{
    public int Height {get; set;} 
    public int Width {get; set;}
    public string Name {get; set;}
    public virtual ICollection<RoomType.Entities.RoomType> RoomTypes { get; set; }
    public virtual ICollection<Seat.Entities.Seat> Seats { get; set; }
        
    #pragma warning disable CS8618
    private Room(){}
    #pragma warning restore CS8618
    private Room(RoomId RoomId, int height, int width,string name, ICollection<RoomType.Entities.RoomType> roomTypes = null!, ICollection<Seat.Entities.Seat> seats = null!)
        : base(RoomId){
            Height = height;
            Width = width;
            Name = name;
            RoomTypes = roomTypes ?? new List<RoomType.Entities.RoomType>();
            Seats = seats ?? new List<Seat.Entities.Seat>();
            
    }
    
    public static Room Create(int height, int width, string name,  ICollection<RoomType.Entities.RoomType> roomTypes = null!, ICollection<Seat.Entities.Seat> seats = null!){

            return new(RoomId.CreateUnique() ,
            height,
            width,
            name,
            roomTypes,
            seats);

    }
}