using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Roles.Common;
using Cinemax.Domain.Role.Entities;
using MediatR;
using Cinemax.Domain.Role.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Roles.Commands.Update;
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleResult>
{
    private readonly IRoleRepository _RoleRepository; 

    public UpdateRoleCommandHandler(IRoleRepository RoleRepository)
    {
        _RoleRepository = RoleRepository;    
    }
    public async Task<RoleResult> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var roleId = RoleId.Create(new (command.Id));
        var Role = _RoleRepository.GetById(roleId);

        if (Role is null)
        {
            throw new Exception("Role with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Role);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Role", ex);
        }
        
        _RoleRepository.Update(Role);

        return new RoleResult(Role);
    }
}