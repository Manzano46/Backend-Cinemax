using Cinemax.Application.Users.Commands.Create;
using Cinemax.Application.Users.Commands.Update;
using Cinemax.Application.Users.Common;
using Cinemax.Application.Users.Queries.Get;
using Cinemax.Application.Users.Queries.Login;
using Cinemax.Application.Users.Queries.Read;
using Cinemax.Contracts.Users;
using Cinemax.Domain.User.Entities;
using Cinemax.Domain.User.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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

    // GET: api/Users
    [HttpGet]
    [Authorize(Roles = "ADMIN,SUPERADMIN")] 
    public async Task<IActionResult> Read()
    {
        var command = new ReadUsersQuery();

        IEnumerable<UserResult> UserResults = await _mediator.Send(command);

        IEnumerable<UserResponse> responses = UserResults.Select(_mapper.Map<UserResponse>);
        
        return Ok(responses);
    }
    
    // DELETE: api/Users/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN,SUPERADMIN")] 
    public async Task<IActionResult> Delete(string id)
    {
        string idFromUser = User.FindFirst("sub")?.Value!;
        UserId UserId = UserId.Create(new (id));
        var command = new DeleteUserCommand(UserId,idFromUser);
        UserResult UserResult = await _mediator.Send(command);
        var response = _mapper.Map<UserResponse>(UserResult);
        return Ok(response);
    }

    // GET: api/Users/{id}
    [HttpGet("{id}")]
    [Authorize(Roles = "ADMIN,SUPERADMIN")] 
    public async Task<IActionResult> Get(string id)
    {
        GetUserRequest getUserRequest = new(id);
        var query = _mapper.Map<GetUserQuery>(getUserRequest);

        UserResult UserResult = await _mediator.Send(query);

        var response = _mapper.Map<UserResponse>(UserResult);

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest){
        var command = _mapper.Map<CreateUserCommand>(registerRequest);
        AuthenticationResult authResult = await _mediator.Send(command);

        var response = _mapper.Map<AuthenticationResponse>(authResult);
        return Ok(response);
    }

    [HttpPost()]
    [Authorize(Roles = "ADMIN,SUPERADMIN")]
    public async Task<IActionResult> Create(CreateUserRequest createUserRequest){
        var command = _mapper.Map<CreateUserCommand>(createUserRequest);
        AuthenticationResult authResult = await _mediator.Send(command);

        var response = _mapper.Map<AuthenticationResponse>(authResult);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest){
        var query = _mapper.Map<LoginQuery>(loginRequest);

        AuthenticationResult authResult = await _mediator.Send(query);

        var response = _mapper.Map<AuthenticationResponse>(authResult);
        return Ok(response);
    }    

    // PATCH: api/users/{id}
    [HttpPatch("{id}")]
    [Authorize(Roles = "USER,ADMIN,SUPERADMIN")] 
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

        string idFromUser = User.FindFirst("sub")?.Value!;

        var command = new UpdateUserCommand(id, patchDoc,idFromUser);
        var actorResult = await _mediator.Send(command);

        return Ok(actorResult);
    }
}