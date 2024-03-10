using Cinemax.Application.Common.Interfaces.Authentication;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Entities;

namespace Cinemax.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository){
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    } 
    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new Exception("user with given email does not exists");
        }

        if(user.Password != password){
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);   
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password, DateTime birth)
    {
        if(_userRepository.GetUserByEmail(email) is not null){
            throw new Exception("User with given email alredy exists");
        }

        User user = new User{
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
            Birth = birth,
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}