using Cinemax.Domain.Common.Models;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Domain.ProjectionAggregate.Entities;

namespace Cinemax.Domain.ProjectionAggregate
{
    public class Projection : AggregateRoot<ProjectionId>
    {
        public MovieId MovieId { get; set; }
        public RoomId RoomId { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Room Room { get; set; }

        #pragma warning disable CS8618
        private Projection() { }
        #pragma warning restore CS8618
        private Projection(ProjectionId projectionId, MovieId movieId, RoomId roomId, DateTime date, int price, Movie movie = null!, Room room = null!)
            : base(projectionId)
        {
            MovieId = movieId;
            RoomId = roomId;
            Date = Date;
            Price = price;
            Movie = movie;
            Room = room;
        }

        public static Projection Create(MovieId movieId, RoomId roomId, DateTime date, int price, Movie movie = null!, Room room = null!)
        {
            return new(ProjectionId.CreateUnique(),
                       movieId,
                       roomId,
                       date,
                       price,
                       movie,
                       room);
        }
    }
}
