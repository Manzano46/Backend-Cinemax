using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Users.Common;
using MediatR;

namespace Cinemax.Application.Users.Queries.Get;
public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResult>
{
    private readonly IUserRepository _UserRepository;

    public GetUserQueryHandler(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;
    }
    public async Task<UserResult> Handle(GetUserQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_UserRepository.GetById(command.UserId)!);
    }
}
