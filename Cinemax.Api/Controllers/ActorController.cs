using Cinemax.Application.Actors.Commands.Create;
using Cinemax.Application.Actors.Common;
using Cinemax.Application.Actors.Queries.Get;
using Cinemax.Application.Actors.Queries.Read;
using Cinemax.Contracts.Actors;
using Cinemax.Domain.Actor.Entities;
using Cinemax.Domain.Actor.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Cinemax.Api.Controllers;

[ApiController]
[Route("actors")]
//[Authorize(Roles = "ADMIN")] 

public class ActorController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ActorController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/actors
    [HttpPost]
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

    // GET: api/actors/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(GetActorRequest getActorRequest)
    {
        var query = _mapper.Map<GetActorQuery>(getActorRequest);

        ActorResult ActorResult = await _mediator.Send(query);

        var response = _mapper.Map<ActorResponse>(ActorResult);

        return Ok(response);
    }

    // PATCH: api/actors/{id}
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new UpdateActorCommand(id, patchDoc);
        var actorResult = await _mediator.Send(command);

        return Ok(actorResult);
    }
}