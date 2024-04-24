using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.User.Entities;
using MediatR;
using Cinemax.Domain.User.ValueObjects;
using Newtonsoft.Json;
using Cinemax.Application.Users.Common;

namespace Cinemax.Application.Users.Commands.Update;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResult>
{
    private readonly IUserRepository _UserRepository; 

    public UpdateUserCommandHandler(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;    
    }
    public async Task<UserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var userId = UserId.Create(new (command.Id));
        var User = _UserRepository.GetById(userId);

        var userFromId = UserId.Create(new (command.idfrom));
        var userFrom = _UserRepository.GetById(userFromId);

        if (User is null)
        {
            throw new Exception("User with given Id does not exist");
        }

        if(userFrom is null)
        {
            throw new Exception("User not found or invalid token");
        }

        try
        {
            command.patchDoc.ApplyTo(User);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the User", ex);
        }

        if(userId != userFromId && userFrom.Role.Name != "SUPERADMIN" && User.Role.Name != "USER")
        {
            throw new Exception("You can't modify an admin");
        } 
        
        _UserRepository.Update(User);

        return new UserResult(User);
    }
}