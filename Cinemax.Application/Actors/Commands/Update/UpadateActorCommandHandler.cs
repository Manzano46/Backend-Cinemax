using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.Entities;
using MediatR;
using Cinemax.Domain.Actor.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Actors.Commands.Update;
public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, ActorResult>
{
    private readonly IActorRepository _actorRepository; 

    public UpdateActorCommandHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;    
    }
    public async Task<ActorResult> Handle(UpdateActorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var actorId = ActorId.Create(new (command.Id));
        var actor = _actorRepository.GetById(actorId);

        if (actor is null)
        {
            throw new Exception("Actor with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(actor);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the actor", ex);
        }
        
        _actorRepository.Update(actor);

        return new ActorResult(actor);
    }
}