using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Room.ValueObjects;

namespace Cinemax.Domain.Room.Entities;
public sealed class Room: Entity<RoomId>{
    public int Height {get; set;} 
    public int Width {get; set;}

    #pragma warning disable CS8618
    private Room(){}
    #pragma warning restore CS8618
    private Room(RoomId RoomId, int height, int width)
        : base(RoomId){
            Height = height;
            Width = width;
    }
    
    public static Room Create(int height, int width){

            return new(RoomId.CreateUnique() ,
            height,
            width);

    }
}