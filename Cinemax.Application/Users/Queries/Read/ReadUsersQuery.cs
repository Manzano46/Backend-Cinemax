using Cinemax.Application.Users.Common;
using MediatR;

namespace Cinemax.Application.Users.Queries.Read;
public record ReadUsersQuery(
    
) : IRequest<IEnumerable<UserResult>>;
