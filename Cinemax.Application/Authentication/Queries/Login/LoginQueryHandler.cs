using Cinemax.Application.Authentication.Common;
using Cinemax.Application.Common.Interfaces.Authentication;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Entities;
using MediatR;

namespace Cinemax.Application.Authentication.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository; 

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;    
    }
    public async Task<AuthenticationResult> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_userRepository.GetUserByEmail(command.Email) is not User user){
            throw new Exception("user with given email does not exists");
        }

        if(user.Password != command.Password){
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);  
    }
}
