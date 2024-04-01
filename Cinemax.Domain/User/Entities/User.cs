using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Domain.User.ValueObjects;

namespace Cinemax.Domain.User.Entities;
public class User : Entity<UserId>{
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Password {get; set;} = null!;
    public DateOnly BirthDay {get; set;}
    public int Points {get; set;} = 0;
    public RoleId RoleId {get; set;} = null!;
    public virtual Role.Entities.Role Role {get; set;} = null!;
    public virtual ICollection<Card.Entities.Card> Cards { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; } = null!;

    #pragma warning disable CS8618
    private User(){}
    #pragma warning restore CS8618

    private User(UserId userId, string firstName, string lastName, string email, string password, DateOnly birth, int points,RoleId roleId, Role.Entities.Role role, ICollection<Card.Entities.Card> cards)
        : base(userId){
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BirthDay = birth;
            Points = points;
            RoleId = roleId;
            Role = role;
            Cards = cards;
    }
    
    public static User Create(string firstName, string lastName,string email, string password, DateOnly birth,  int points,RoleId roleId, Role.Entities.Role role, ICollection<Card.Entities.Card> cards){

            return new(UserId.CreateUnique() ,
            firstName,
            lastName,
            email,
            password,
            birth,
            points,
            roleId,
            role,
            cards);

    }
}