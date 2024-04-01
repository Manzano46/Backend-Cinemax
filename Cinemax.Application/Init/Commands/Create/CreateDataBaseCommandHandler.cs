using Cinemax.Application.Actors.Commands.Create;
using Cinemax.Application.Actors.Common;
using Cinemax.Application.Cards.Commands.Create;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Countries.Commands.Create;
using Cinemax.Application.Countries.Common;
using Cinemax.Application.Directors.Commands.Create;
using Cinemax.Application.Directors.Common;
using Cinemax.Application.Discounts.Commands.Create;
using Cinemax.Application.Genres.Commands.Create;
using Cinemax.Application.Genres.Common;
using Cinemax.Application.Init.Commands.Create;
using Cinemax.Application.Movies.Commands.Create;
using Cinemax.Application.Movies.Common;
using Cinemax.Application.PaymentTypes.Commands.Create;
using Cinemax.Application.Projections.Commands.Create;
using Cinemax.Application.Roles.Commands.Create;
using Cinemax.Application.Rooms.Commands.Create;
using Cinemax.Application.Rooms.Common;
using Cinemax.Application.RoomTypes.Commands.Create;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Application.Users.Commands.Create;
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
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.RoomType.Entities;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.User.Entities;
using MediatR;
using Microsoft.VisualBasic;

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
    private readonly IMediator _Mediator;
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
    IUserRepository userRepository,
    IMediator mediator)
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
        _Mediator = mediator;
    }
    public async Task<string> Handle(CreateDataBaseCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        CreateActorCommand actor1 = new CreateActorCommand("aaMariah","Carey",[]);
        CreateActorCommand actor2 = new CreateActorCommand("aaCeline","Dion",[]);

        ActorResult Actor1 = await _Mediator.Send(actor1);      
        ActorResult Actor2 = await _Mediator.Send(actor2);  
        
        CreateCardCommand card1 = new(CardId.Create(1323));
        CreateCardCommand card2 = new(CardId.Create(3435));

        var Card1 = await _Mediator.Send(card1);
        var Card2 = await _Mediator.Send(card2);

        CreateCountryCommand country1 = new("aCuba",[]);
        CreateCountryCommand country2 = new("aEUA",[]);

        CountryResult Country1 = await _Mediator.Send(country1);
        CountryResult Country2 = await _Mediator.Send(country2);

        CreateDirectorCommand director1 = new("aSteven","Spielberg");
        CreateDirectorCommand director2 = new("aJames","Cameron");

        DirectorResult Director1 = await _Mediator.Send(director1);
        DirectorResult Director2 = await _Mediator.Send(director2);

        CreateDiscountCommand discount1 = new("adia de las madres",0.1f);
        CreateDiscountCommand discount2 = new("adia del perro",0.2f);

        var Discount1 = await _Mediator.Send(discount1);
        var Discount2 = await _Mediator.Send(discount2);

        CreateGenreCommand genre1 = new("aAction");
        CreateGenreCommand genre2 = new("aComedy");

        GenreResult Genre1 = await _Mediator.Send(genre1);
        GenreResult Genre2 = await _Mediator.Send(genre2);

        CreatePaymentTypeCommand paymentType1 = new("aCredit Card");
        CreatePaymentTypeCommand paymentType2 = new("aDebit Card");

        var PaymentType1 = await _Mediator.Send(paymentType1);
        var PaymentType2 = await _Mediator.Send(paymentType2);

        CreateMovieCommand movie1 = new("aTitanic", "asdasdasdas", TimeSpan.Zero, DateTime.Today, "asd", "asd", "asd", "asd", "asd",[],[],[],[]);
        
        /* [Actor1.Actor.Id.ToString() , Actor2.Actor.Id.ToString()], [Country1.Country.Id.ToString(), Country2.Country.Id.ToString()], [Director1.Director.Id.ToString(), Director2.Director.Id.ToString()], [Genre1.Genre.Id.ToString(), Genre2.Genre.Id.ToString()]);
*/
        CreateMovieCommand movie2 = new("aAvatar", "asdasdasdada", TimeSpan.Zero, DateTime.Now, "asd", "asd", "asd", "asd", "asd",[],[],[],[]);

        MovieResult Movie1 = await _Mediator.Send(movie1);
        MovieResult Movie2 = await _Mediator.Send(movie2);

        CreateRoleCommand role1 = new("ADMIN");
        CreateRoleCommand role2 = new("USER");

        var Role1 = await _Mediator.Send(role1);
        var Role2 = await _Mediator.Send(role2);

        CreateRoomTypeCommand roomType1 = new("3D");
        CreateRoomTypeCommand roomType2 = new("2D");

        RoomTypeResult RoomType1 = await _Mediator.Send(roomType1);
        RoomTypeResult RoomType2 = await _Mediator.Send(roomType2);
        
        CreateRoomCommand room1 = new(2, 5, "Avellaneda",[RoomType1.RoomType.Id]);
        CreateRoomCommand room2 = new(3, 3, "Lanus",[RoomType2.RoomType.Id, RoomType1.RoomType.Id]);

        RoomResult Room1 = await _Mediator.Send(room1);
        RoomResult Room2 = await _Mediator.Send(room2);

        CreateUserCommand user1 = new("kevin", "manzano", "kevin@gmail.com", "1234kevin", DateOnly.MinValue, 14, role1, []);
        CreateUserCommand user2 = new("user", "user", "user@gmail.com", "userpassword", DateOnly.MinValue, 0, role2, []);

        var User1 = await _Mediator.Send(user1);
        var User2 = await _Mediator.Send(user2);

        CreateProjectionCommand projection1 = new(Movie1.Movie.Id, Room2.Room.Id, DateTime.UtcNow, 150);
        CreateProjectionCommand projection2 = new(Movie2.Movie.Id, Room1.Room.Id, DateTime.MinValue, 20);

        var Projection1 = await _Mediator.Send(projection1);
        var Projection2 = await _Mediator.Send(projection2);
        
        return "OK";
    }
}
