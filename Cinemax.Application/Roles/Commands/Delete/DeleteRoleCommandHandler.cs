using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Roles.Common;
using Cinemax.Domain.Role.Entities;
using MediatR;

namespace Cinemax.Application.Roles.Commands.Delete;
public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, RoleResult>
{
    private readonly IRoleRepository _roleRepository; 

    public DeleteRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;    
    }
    public async Task<RoleResult> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_roleRepository.GetById(command.Id) is not Role role){
            throw new Exception("Role not found");
        }
        _roleRepository.Delete(command.Id);
        return new RoleResult(role);
    }
}