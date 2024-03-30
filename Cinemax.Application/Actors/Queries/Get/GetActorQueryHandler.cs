using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Actors.Common;
using MediatR;

namespace Cinemax.Application.Actors.Queries.Get;
public class GetActorQueryHandler : IRequestHandler<GetActorQuery, ActorResult>
{
    private readonly IActorRepository _ActorRepository;

    public GetActorQueryHandler(IActorRepository ActorRepository)
    {
        _ActorRepository = ActorRepository;
    }
    public async Task<ActorResult> Handle(GetActorQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_ActorRepository.GetById(command.ActorId)!);
    }
}
