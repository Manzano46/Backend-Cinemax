using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Users.Common;
using Cinemax.Application.Users.Queries.Read;
using MediatR;

namespace Cinemax.Application.Users.Query.Read;
public class ReadUsersQueryHandler : IRequestHandler<ReadUsersQuery, IEnumerable<UserResult>>
{
    private readonly IUserRepository _UserRepository; 

    public ReadUsersQueryHandler(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;    
    }
    public async Task<IEnumerable<UserResult>> Handle(ReadUsersQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _UserRepository.GetAllUsers().Select(x => new UserResult(x));
    }
}
