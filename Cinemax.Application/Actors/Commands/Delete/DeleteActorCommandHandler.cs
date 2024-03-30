using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.Entities;
using MediatR;

namespace Cinemax.Application.Actors.Commands.Delete;
public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, ActorResult>
{
    private readonly IActorRepository _actorRepository; 

    public DeleteActorCommandHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;    
    }
    public async Task<ActorResult> Handle(DeleteActorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_actorRepository.GetById(command.Id) is not Actor actor){
            throw new Exception("Actor not found");
        }
        _actorRepository.Delete(command.Id);
        
        return new ActorResult(actor);
    }
}