using Cinemax.Domain.Common.Models;
using Cinemax.Domain.MovieAggregate.ValueObjects;
using Cinemax.Domain.User.ValueObjects;

namespace Cinemax.Domain.User.Entities;
public class User : Entity<UserId>{
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Password {get; set;} = null!;
    public DateOnly Birth {get; set;}
    public int Points {get; set;} = 0;

    #pragma warning disable CS8618
    private User(){}
    #pragma warning restore CS8618

    private User(UserId userId, string firstName, string lastName, string email, string password, DateOnly birth)
        : base(userId){
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Birth = birth;
    }
    
    public static User Create(string firstName, string lastName, string email, string password, DateOnly birth){

            return new(UserId.CreateUnique() ,
            firstName,
            lastName,
            email,
            password,
            birth);

    }
}