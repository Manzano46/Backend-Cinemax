namespace Cinemax.Domain.User;
public class User{
    public Guid Id {get; set;} = Guid.NewGuid();
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Password {get; set;} = null!;
    public DateOnly Birth {get; set;}
    public int Points {get; set;} = 0;
}