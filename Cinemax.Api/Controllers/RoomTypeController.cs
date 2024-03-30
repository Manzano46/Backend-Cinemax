using Cinemax.Application.RoomTypes.Commands.Create;
using Cinemax.Application.RoomTypes.Commands.Delete;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Application.RoomTypes.Queries.Read;
using Cinemax.Contracts.RoomTypes;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("roomtypes")]

public class RoomTypeController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RoomTypeController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/roomtypes
    [HttpPost]
   
    public async Task<IActionResult> Create(CreateRoomTypeRequest createRoomTypeRequest)
    {
        var command = _mapper.Map<CreateRoomTypeCommand>(createRoomTypeRequest);

        RoomTypeResult RoomTypeResult = await _mediator.Send(command);

        var response = _mapper.Map<ProjectionResponse>(RoomTypeResult);
        return Ok(response);
    }

    // GET: api/roomtypes
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadRoomTypesQuery();

        IEnumerable<RoomTypeResult> RoomTypeResults = await _mediator.Send(command);

        IEnumerable<ProjectionResponse> responses = RoomTypeResults.Select(_mapper.Map<ProjectionResponse>);
        
        return Ok(responses);
    }

    // DELETE: api/roomtypes/{name}
    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        var command = new DeleteRoomTypeCommand(name);

        RoomTypeResult RoomTypeResult = await _mediator.Send(command);

        var response = _mapper.Map<ProjectionResponse>(RoomTypeResult);

        return Ok(response);
    }

}