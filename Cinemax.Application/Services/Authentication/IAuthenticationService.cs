namespace Cinemax.Application.Services.Authentication;

public interface IAuthenticationService{
    AuthenticationResult Register(string firstName, string lastName, string email, string password, DateTime birth);
    AuthenticationResult Login(string email, string password);    
}