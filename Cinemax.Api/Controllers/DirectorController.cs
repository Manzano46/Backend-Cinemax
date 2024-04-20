using Cinemax.Application.Directors.Commands.Create;
using Cinemax.Application.Directors.Common;
using Cinemax.Application.Directors.Queries.Get;
using Cinemax.Application.Directors.Queries.Read;
using Cinemax.Contracts.Directors;
using Cinemax.Domain.Director.Entities;
using Cinemax.Domain.Director.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("directors")]
//[Authorize(Roles = "ADMIN")] 

public class DirectorController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DirectorController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/directors
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateDirectorRequest createDirectorRequest)
    {
        var command = _mapper.Map<CreateDirectorCommand>(createDirectorRequest);

        DirectorResult directorResult = await _mediator.Send(command);

        var response = _mapper.Map<DirectorResponse>(directorResult);
        return Ok(response);
    }

    // GET: api/directors
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadDirectorsQuery();

        IEnumerable<DirectorResult> directorResults = await _mediator.Send(command);

        IEnumerable<DirectorResponse> responses = directorResults.Select(directorResult => _mapper.Map<DirectorResponse>(directorResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/directors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        DirectorId directorId = DirectorId.Create(new (id));
        var command = new DeleteDirectorCommand(directorId);
        DirectorResult directorResult = await _mediator.Send(command);
        var response = _mapper.Map<DirectorResponse>(directorResult);
        return Ok(response);
    }

    // GET: api/directors/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        GetDirectorRequest getDirectorRequest = new(id);
        var query = _mapper.Map<GetDirectorQuery>(getDirectorRequest);

        DirectorResult DirectorResult = await _mediator.Send(query);

        var response = _mapper.Map<DirectorResponse>(DirectorResult);

        return Ok(response);
    }

    
    // PATCH: api/directors/{id}
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

        var command = new UpdateDirectorCommand(id, patchDoc);
        var actorResult = await _mediator.Send(command);

        return Ok(actorResult);
    }
}