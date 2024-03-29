using Cinemax.Application.Rooms.Commands.Create;
using Cinemax.Application.Rooms.Commands.Delete;
using Cinemax.Application.Rooms.Common;
using Cinemax.Application.Rooms.Queries.Read;
using Cinemax.Contracts.Rooms;
using Cinemax.Domain.Room.Entities;
using Cinemax.Domain.Room.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("rooms")]

public class RoomController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RoomController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/rooms
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateRoomRequest createRoomRequest)
    {
        var command = _mapper.Map<CreateRoomCommand>(createRoomRequest);

        RoomResult RoomResult = await _mediator.Send(command);

        var response = _mapper.Map<RoomResponse>(RoomResult);
        return Ok(response);
    }

    // GET: api/rooms
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadRoomsQuery();

        IEnumerable<RoomResult> RoomResults = await _mediator.Send(command);

        IEnumerable<RoomResponse> responses = RoomResults.Select(_mapper.Map<RoomResponse>);
        
        return Ok(responses);
    }


    
    // DELETE: api/Rooms/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        RoomId RoomId = RoomId.Create(new (id));
        var command = new DeleteRoomCommand(RoomId);
        RoomResult RoomResult = await _mediator.Send(command);
        var response = _mapper.Map<RoomResponse>(RoomResult);
        return Ok(response);
    }
}