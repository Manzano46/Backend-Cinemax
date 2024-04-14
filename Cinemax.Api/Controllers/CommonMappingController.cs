using Cinemax.Application.Init.Commands.Create;
using Cinemax.Application.Users.Commands.Create;
using Cinemax.Application.Users.Common;
using Cinemax.Application.Users.Queries.Get;
using Cinemax.Application.Users.Queries.Login;
using Cinemax.Application.Users.Queries.Read;
using Cinemax.Contracts.Users;
using Cinemax.Domain.User.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("common")]
//[Authorize(Roles = "ADMIN")] 
public class CommonController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CommonController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // GET: api/common/init
    [HttpGet("init")]
    public async Task<IActionResult> Init()
    {
        var command = new CreateDataBaseCommand();

        string result = await _mediator.Send(command);

        return Ok("DATABASE CREATED" + result);
    }
    
}