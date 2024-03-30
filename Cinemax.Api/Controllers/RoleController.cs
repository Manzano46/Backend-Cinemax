using Cinemax.Application.Roles.Commands.Create;
using Cinemax.Application.Roles.Common;
using Cinemax.Application.Roles.Queries.Read;
using Cinemax.Contracts.Roles;
using Cinemax.Domain.Role.Entities;
using Cinemax.Domain.Role.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("roles")]

public class RoleController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RoleController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/Roles
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateRoleRequest createRoleRequest)
    {
        var command = _mapper.Map<CreateRoleCommand>(createRoleRequest);

        RoleResult roleResult = await _mediator.Send(command);

        var response = _mapper.Map<RoleResponse>(roleResult);
        return Ok(response);
    }

    // GET: api/roles
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadRolesQuery();

        IEnumerable<RoleResult> roleResults = await _mediator.Send(command);

        IEnumerable<RoleResponse> responses = roleResults.Select(RoleResult => _mapper.Map<RoleResponse>(RoleResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/roles/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        RoleId roleId = RoleId.Create(new (id));
        var command = new DeleteRoleCommand(roleId);
        RoleResult roleResult = await _mediator.Send(command);
        var response = _mapper.Map<RoleResponse>(roleResult);
        return Ok(response);
    }

    /*
    // PUT: api/Roles/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCountrieCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/Roles/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCountrieCommand { Id = id });
        return NoContent();
    }
    */
}