using Cinemax.Application.Users.Commands.Create;
using Cinemax.Application.Users.Common;
using Cinemax.Application.Users.Queries.Get;
using Cinemax.Application.Users.Queries.Read;
using Cinemax.Contracts.Users;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("users")]

public class UserController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/Users
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateUserRequest createUserRequest)
    {
        var command = _mapper.Map<CreateUserCommand>(createUserRequest);

        UserResult UserResult = await _mediator.Send(command);

        var response = _mapper.Map<UserResponse>(UserResult);
        return Ok(response);
    }

    // GET: api/Users
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadUsersQuery();

        IEnumerable<UserResult> UserResults = await _mediator.Send(command);

        IEnumerable<UserResponse> responses = UserResults.Select(UserResult => _mapper.Map<UserResponse>(UserResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/Users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        UserId UserId = UserId.Create(new (id));
        var command = new DeleteUserCommand(UserId);
        UserResult UserResult = await _mediator.Send(command);
        var response = _mapper.Map<UserResponse>(UserResult);
        return Ok(response);
    }

    // GET: api/Users/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(GetUserRequest getUserRequest)
    {
        var query = _mapper.Map<GetUserQuery>(getUserRequest);

        UserResult UserResult = await _mediator.Send(query);

        var response = _mapper.Map<UserResponse>(UserResult);

        return Ok(response);
    }

    /*
    // PUT: api/Users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/Users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteUserCommand { Id = id });
        return NoContent();
    }
    */

}