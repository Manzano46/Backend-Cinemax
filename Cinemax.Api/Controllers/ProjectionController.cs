using Cinemax.Application.Projections.Commands.Create;
using Cinemax.Application.Projections.Commands.Delete;
using Cinemax.Application.Projections.Common;
using Cinemax.Application.Projections.Queries.Read;
using Cinemax.Contracts.Projections;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinemax.Application.Projections.Queries.Get;
using Microsoft.AspNetCore.Authorization;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("projections")]
//[Authorize(Roles = "ADMIN")] 

public class ProjectionController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProjectionController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/projections
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateProjectionRequest createProjectionRequest)
    {
        var command = _mapper.Map<CreateProjectionCommand>(createProjectionRequest);

        ProjectionResult ProjectionResult = await _mediator.Send(command);

        var response = _mapper.Map<ProjectionResponse>(ProjectionResult);
        return Ok(response);
    }

    // GET: api/projections
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var query = new ReadProjectionQuery();

        IEnumerable<ProjectionResult> ProjectionResults = await _mediator.Send(query);

        IEnumerable<ProjectionResponse> responses = ProjectionResults.Select(_mapper.Map<ProjectionResponse>);
        
        return Ok(responses);
    }

    // DELETE: api/projections/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        DeleteProjectionRequest deleteProjectionRequest = new(id);
        var command = _mapper.Map<DeleteProjectionCommand>(deleteProjectionRequest);

        ProjectionResult ProjectionResult = await _mediator.Send(command);

        var response = _mapper.Map<ProjectionResponse>(ProjectionResult);

        return Ok(response);
    }

    // GET: api/projections/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        GetProjectionRequest getProjectionRequest = new(id);
        var query = _mapper.Map<GetProjectionQuery>(getProjectionRequest);

        ProjectionResult ProjectionResult = await _mediator.Send(query);

        var response = _mapper.Map<ProjectionResponse>(ProjectionResult);

        return Ok(response);
    }
}