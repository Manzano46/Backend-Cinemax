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
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("directors")]

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
    public async Task<IActionResult> Get(GetDirectorRequest getDirectorRequest)
    {
        var query = _mapper.Map<GetDirectorQuery>(getDirectorRequest);

        DirectorResult DirectorResult = await _mediator.Send(query);

        var response = _mapper.Map<DirectorResponse>(DirectorResult);

        return Ok(response);
    }

    /*
    // PUT: api/Directors/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateDirectorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/Directors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteDirectorCommand { Id = id });
        return NoContent();
    }
    */

}