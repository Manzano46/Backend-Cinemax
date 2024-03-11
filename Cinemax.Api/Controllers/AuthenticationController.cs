using Cinemax.Application.Authentication.Commands.Register;
using Cinemax.Application.Authentication.Common;
using Cinemax.Application.Authentication.Queries.Login;
using Cinemax.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase{
    private readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest){
        var command = new RegisterCommand(registerRequest.FirstName, registerRequest.LastName, registerRequest.Email, registerRequest.Password, registerRequest.Birth);

        AuthenticationResult authResult = await _mediator.Send(command);

        var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.User.Birth, authResult.User.Points, authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest){
        var query = new LoginQuery(loginRequest.Email, loginRequest.Password);

        AuthenticationResult authResult = await _mediator.Send(query);

        var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.User.Birth, authResult.User.Points, authResult.Token);

        return Ok(response);
    }
}