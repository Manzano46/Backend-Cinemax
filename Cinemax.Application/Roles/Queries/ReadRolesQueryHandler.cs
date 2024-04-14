using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Roles.Common;
using Cinemax.Application.Roles.Queries.Read;
using MediatR;

namespace Cinemax.Application.Roles.Query.Read;
public class ReadRolesQueryHandler : IRequestHandler<ReadRolesQuery, IEnumerable<RoleResult>>
{
    private readonly IRoleRepository _roleRepository; 

    public ReadRolesQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;    
    }
    public async Task<IEnumerable<RoleResult>> Handle(ReadRolesQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _roleRepository.GetAll().Select(x => new RoleResult(x));
    }
}
