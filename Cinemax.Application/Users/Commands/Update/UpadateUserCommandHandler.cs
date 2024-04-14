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

        if (User is null)
        {
            throw new Exception("User with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(User);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the User", ex);
        }
        
        _UserRepository.Update(User);

        return new UserResult(User);
    }
}