using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.User.ValueObjects;

namespace Cinemax.Domain.User.Entities;
public class User : Entity<UserId>{
    public string Name {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Password {get; set;} = null!;
    public DateOnly BirthDay {get; set;}
    public int Points {get; set;} = 0;
    public Role.Entities.Role Role {get; set;} = null!;
    public virtual ICollection<Card> Cards { get; set; } = null!;

    #pragma warning disable CS8618
    private User(){}
    #pragma warning restore CS8618

    private User(UserId userId, string name, string email, string password, DateOnly birth, int points, Role.Entities.Role role, ICollection<Card> cards)
        : base(userId){
            Name = name;
            Email = email;
            Password = password;
            BirthDay = birth;
            Points = points;
            Role = role;
            Cards = cards;
    }
    
    public static User Create(string name, string email, string password, DateOnly birth,  int points, Role.Entities.Role role, ICollection<Card> cards){

            return new(UserId.CreateUnique() ,
            name,
            email,
            password,
            birth,
            points,
            role,
            cards);

    }
}