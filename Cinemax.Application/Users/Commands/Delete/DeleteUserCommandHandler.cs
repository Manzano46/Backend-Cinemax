using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Users.Common;
using Cinemax.Domain.User.Entities;
using MediatR;

namespace Cinemax.Application.Users.Commands.Delete;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserResult>
{
    private readonly IUserRepository _UserRepository; 

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _UserRepository = userRepository;    
    }
    public async Task<UserResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_UserRepository.GetById(command.Id) is not User user){
            throw new Exception("User not found");
        }
        _UserRepository.Delete(command.Id);
        
        return new UserResult(user);
    }
}