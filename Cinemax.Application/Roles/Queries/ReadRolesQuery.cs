using Cinemax.Application.Roles.Common;
using MediatR;

namespace Cinemax.Application.Roles.Queries.Read;
public record ReadRolesQuery(
    
) : IRequest<IEnumerable<RoleResult>>;
