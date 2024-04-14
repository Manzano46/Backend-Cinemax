using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Actors.Common;
using Cinemax.Application.Actors.Queries.Read;
using MediatR;

namespace Cinemax.Application.Actors.Query.Read;
public class ReadActorsQueryHandler : IRequestHandler<ReadActorsQuery, IEnumerable<ActorResult>>
{
    private readonly IActorRepository _actorRepository; 

    public ReadActorsQueryHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;    
    }
    public async Task<IEnumerable<ActorResult>> Handle(ReadActorsQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _actorRepository.GetAll().Select(x => new ActorResult(x));
    }
}
