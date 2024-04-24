using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Users.Common;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
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
        
        UserId userId = UserId.Create(new (command.idfrom));
        
        if(_UserRepository.GetById(userId) is not User userFrom){
            throw new Exception("User not found or invalid token");
        }

        if((user.Role.Name == "ADMIN" && userFrom.Role.Name != "SUPERADMIN") || user.Role.Name == "SUPERADMIN")
        {
            throw new Exception("You can't delete an admin");
        }


        
        _UserRepository.Delete(command.Id);
        
        return new UserResult(user);
    }
}