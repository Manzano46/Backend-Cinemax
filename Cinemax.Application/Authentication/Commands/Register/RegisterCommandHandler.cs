using Cinemax.Application.Authentication.Common;
using Cinemax.Application.Common.Interfaces.Authentication;
using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.MovieAggregate.Entities;
using Cinemax.Domain.User.Entities;
using MediatR;

namespace Cinemax.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository; 

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;    
    }
    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_userRepository.GetUserByEmail(command.Email) is not null){
            throw new Exception("User with given email alredy exists");
        }

        User user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            // poner la fecha
            DateOnly.MaxValue
        );

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
