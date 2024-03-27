using Cinemax.Application.Actors.Commands.Create;
using Cinemax.Application.Actors.Common;
using Cinemax.Application.Actors.Queries.Read;
using Cinemax.Contracts.Actors;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("actors")]

public class ActorController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ActorController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/actors
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateActorRequest createActorRequest)
    {
        var command = _mapper.Map<CreateActorCommand>(createActorRequest);

        ActorResult actorResult = await _mediator.Send(command);

        var response = _mapper.Map<ActorResponse>(actorResult);
        return Ok(response);
    }

    // GET: api/actors
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadActorsQuery();

        IEnumerable<ActorResult> actorResults = await _mediator.Send(command);

        IEnumerable<ActorResponse> responses = actorResults.Select(actorResult => _mapper.Map<ActorResponse>(actorResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/actors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        ActorId actorId = ActorId.Create(new (id));
        var command = new DeleteActorCommand(actorId);
        ActorResult actorResult = await _mediator.Send(command);
        var response = _mapper.Map<ActorResponse>(actorResult);
        return Ok(response);
    }

    /*
    // PUT: api/Actors/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateActorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/Actors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteActorCommand { Id = id });
        return NoContent();
    }
    */
}