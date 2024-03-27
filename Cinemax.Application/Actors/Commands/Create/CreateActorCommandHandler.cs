using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Actors.Common;
using Cinemax.Domain.Actor.Entities;
using MediatR;

namespace Cinemax.Application.Actors.Commands.Create;
public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, ActorResult>
{
    private readonly IActorRepository _actorRepository; 

    public CreateActorCommandHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;    
    }
    public async Task<ActorResult> Handle(CreateActorCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_actorRepository.GetByName(command.Firstname,command.Lastname) is not null){
            throw new Exception("Actor with given name alredy exists");
        }

        Actor actor = Actor.Create(
            command.Firstname,
            command.Lastname
        );

        _actorRepository.Add(actor);

        return new ActorResult(actor);
    }

}
