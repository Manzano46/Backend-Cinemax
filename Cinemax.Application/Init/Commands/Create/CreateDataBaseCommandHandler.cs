using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Init.Commands.Create;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Genre.Entities;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.ProjectionAggregate;
using Cinemax.Domain.ProjectionAggregate.Entities;
using MediatR;

namespace Cinemax.Application.DataBases.Commands.Create;
public class CreateDataBaseCommandHandler : IRequestHandler<CreateDataBaseCommand, string>
{
    private readonly IActorRepository _ActorRepository;
    private readonly ICardRepository _CardRepository;
    private readonly ICountryRepository _CountryRepository;
    private readonly IDirectorRepository _DirectorRepository;
    private readonly IDiscountRepository _DiscountRepository;
    private readonly IGenreRepository _GenreRepository;
    private readonly IPaymentTypeRepository _PaymentTypeRepository;
    private readonly IProjectionRepository _ProjectionRepository;
    private readonly IMovieRepository _MovieRepository;
    private readonly IRoleRepository _RoleRepository;
    private readonly IRoomRepository _RoomRepository;
    private readonly IRoomTypeRepository _RoomTypeRepository;
    private readonly ISeatRepository _SeatRepository;
    private readonly ITicketRepository _TicketRepository;
    private readonly IUserRepository _UserRepository;
    
    public CreateDataBaseCommandHandler(IActorRepository actorRepository,
   ICardRepository cardRepository,
    ICountryRepository countryRepository,
    IDirectorRepository directorRepository,
    IDiscountRepository discountRepository,
    IGenreRepository genreRepository,
    IPaymentTypeRepository paymentTypeRepository,
    IProjectionRepository projectionRepository,
    IMovieRepository movieRepository,
    IRoleRepository roleRepository,
    IRoomRepository roomRepository,
    IRoomTypeRepository roomTypeRepository,
    ISeatRepository seatRepository,
    ITicketRepository ticketRepository,
    IUserRepository userRepository)
    {
        _ActorRepository = actorRepository;
        _CardRepository = cardRepository;
        _CountryRepository = countryRepository;
        _DirectorRepository = directorRepository;
        _DiscountRepository = discountRepository;
        _GenreRepository =  genreRepository;
        _PaymentTypeRepository = paymentTypeRepository;
        _ProjectionRepository = projectionRepository;
        _MovieRepository = movieRepository;
        _RoleRepository = roleRepository;
        _RoomRepository = roomRepository;
        _RoomTypeRepository = roomTypeRepository;
        _SeatRepository = seatRepository;
        _TicketRepository = ticketRepository;
        _UserRepository = userRepository;
    }
    public async Task<string> Handle(CreateDataBaseCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        Actor actor1 = Actor.Create("Mariah","Carey");
        Actor actor2 = Actor.Create("Celine","Dion");

        _ActorRepository.Add(actor1);
        _ActorRepository.Add(actor2);
        
        Card card1 = Card.Create(CardId.Create(123));
        Card card2 = Card.Create(CardId.Create(345));

        _CardRepository.Add(card1);
        _CardRepository.Add(card2);

        Country country1 = Country.Create("Cuba");
        Country country2 = Country.Create("EUA");

        _CountryRepository.Add(country1);
        _CountryRepository.Add(country2);

        
        Director director1 = Director.Create("Steven","Spielberg");
        Director director2 = Director.Create("James","Cameron");

        _DirectorRepository.Add(director1);
        _DirectorRepository.Add(director2);

        Discount discount1 = Discount.Create("dia de las madres",0.1f);
        Discount discount2 = Discount.Create("dia del perro",0.2f);

        _DiscountRepository.Add(discount1);
        _DiscountRepository.Add(discount2);

        Genre genre1 = Genre.Create("Action");
        Genre genre2 = Genre.Create("Comedy");

        _GenreRepository.Add(genre1);
        _GenreRepository.Add(genre2);

        PaymentType paymentType1 = PaymentType.Create("Credit Card");
        PaymentType paymentType2 = PaymentType.Create("Debit Card");

        _PaymentTypeRepository.Add(paymentType1);
        _PaymentTypeRepository.Add(paymentType2);

        /*
        Projection projection1 = Projection.Create(DateTime.Now, 1, 1);
        Projection projection2 = Projection.Create(DateTime.Now, 2, 2);

        _ProjectionRepository.Add(projection1);
        _ProjectionRepository.Add(projection2);

        Movie movie1 = Movie.Create("Titanic", 1997, 1, 1, 1, 1, 1, 1);
        Movie movie2 = Movie.Create("Avatar", 2009, 2, 2, 2, 2, 2, 2);

        _MovieRepository.Add(movie1);
        _MovieRepository.Add(movie2);

        Role role1 = Role.Create("Admin");
        Role role2 = Role.Create("User");

        _RoleRepository.Add(role1);
        _RoleRepository.Add(role2);

        Room room1 = Room.Create("Room 1", 1, 1);
        Room room2 = Room.Create("Room 2", 2, 2);

        _RoomRepository.Add(room1);
        _RoomRepository.Add(room2);

        RoomType roomType1 = RoomType.Create("3D");
        RoomType roomType2 = RoomType.Create("2D");

        _RoomTypeRepository.Add(roomType1);
        _RoomTypeRepository.Add(roomType2);

        Seat seat1 = Seat.Create(1, 1, 1);
        Seat seat2 = Seat.Create(2, 2, 2);

        _SeatRepository.Add(seat1);
        _SeatRepository.Add(seat2);

        Ticket ticket1 = Ticket.Create(1, 1, 1, 1, 1, 1);
        Ticket ticket2 = Ticket.Create(2, 2, 2, 2, 2, 2);
        
        _TicketRepository.Add(ticket1);
        _TicketRepository.Add(ticket2);

        User user1 = User.Create("admin", "admin")
            .AddRole(role1);

        User user2 = User.Create("user", "user")
            .AddRole(role2);

        _UserRepository.Add(user1);
        _UserRepository.Add(user2);

        */


        return "OK";
    }
}
