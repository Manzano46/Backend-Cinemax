using Cinemax.Application.Rooms.Commands.Create;
using Cinemax.Application.Rooms.Common;
using Cinemax.Application.Rooms.Queries.Read;
using Cinemax.Contracts.Rooms;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinemax.Application.RoomTypes.Commands.Delete;
using Cinemax.Application.Rooms.Commands.Delete;
using Cinemax.Application.Rooms.Queries.Get;

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
        var command = new ReadRoomQuery();

        IEnumerable<RoomResult> RoomResults = await _mediator.Send(command);

        IEnumerable<RoomResponse> responses = RoomResults.Select(_mapper.Map<RoomResponse>);
        
        return Ok(responses);
    }


   
    // DELETE: api/rooms/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DeleteRoomRequest deleteRoomRequest )
    {
        var command = _mapper.Map<DeleteRoomCommand>(deleteRoomRequest);

        RoomResult roomResult = await _mediator.Send(command);

        var response = _mapper.Map<RoomResponse>(roomResult);

        return Ok(response);
    }

    // GET: api/rooms/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(GetRoomRequest getRoomRequest)
    {
        var query = _mapper.Map<GetRoomQuery>(getRoomRequest);

        RoomResult RoomResult = await _mediator.Send(query);

        var response = _mapper.Map<RoomResponse>(RoomResult);

        return Ok(response);
    }
}