using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Room.ValueObjects;
using Cinemax.Domain.RoomType.Entities;

namespace Cinemax.Domain.Room.Entities;
public class Room: Entity<RoomId>{
    public int Height {get; set;} 
    public int Width {get; set;}
    public virtual ICollection<RoomType.Entities.RoomType> RoomTypes { get; set; }
        
    #pragma warning disable CS8618
    private Room(){}
    #pragma warning restore CS8618
    private Room(RoomId RoomId, int height, int width, ICollection<RoomType.Entities.RoomType> roomTypes = null!)
        : base(RoomId){
            Height = height;
            Width = width;
            RoomTypes = roomTypes ?? new List<RoomType.Entities.RoomType>();
    }
    
    public static Room Create(int height, int width,  ICollection<RoomType.Entities.RoomType> roomTypes = null!){

            return new(RoomId.CreateUnique() ,
            height,
            width,
            roomTypes);

    }
}