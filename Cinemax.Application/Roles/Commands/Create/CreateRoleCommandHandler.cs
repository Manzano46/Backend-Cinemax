using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Roles.Common;
using Cinemax.Domain.Role.Entities;
using MediatR;

namespace Cinemax.Application.Roles.Commands.Create;
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleResult>
{
    private readonly IRoleRepository _roleRepository; 

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;    
    }
    public async Task<RoleResult> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_roleRepository.GetByName(command.Name) is not null){
            throw new Exception("Role with given name alredy exists");
        }

        Role role = Role.Create(
            command.Name
        );

        _roleRepository.Insert(role);

        return new RoleResult(role);
    }

}
