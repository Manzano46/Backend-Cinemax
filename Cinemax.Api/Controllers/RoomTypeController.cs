using Cinemax.Application.RoomTypes.Commands.Create;
using Cinemax.Application.RoomTypes.Commands.Delete;
using Cinemax.Application.RoomTypes.Common;
using Cinemax.Application.RoomTypes.Queries.Get;
using Cinemax.Application.RoomTypes.Queries.Read;
using Cinemax.Contracts.RoomTypes;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("roomtypes")]
//[Authorize(Roles = "ADMIN")] 
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

        var response = _mapper.Map<RoomTypeResponse>(RoomTypeResult);
        return Ok(response);
    }

    // GET: api/roomtypes
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadRoomTypesQuery();

        IEnumerable<RoomTypeResult> RoomtypeResults = await _mediator.Send(command);

        IEnumerable<RoomTypeResponse> responses = RoomtypeResults.Select(_mapper.Map<RoomTypeResponse>);
        
        return Ok(responses);
    }

    // DELETE: api/roomtypes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        DeleteRoomTypeRequest deleteRoomTypeRequest = new(id);
        var command = _mapper.Map<DeleteRoomTypeCommand>(deleteRoomTypeRequest);

        RoomTypeResult roomTypeResult = await _mediator.Send(command);

        var response = _mapper.Map<RoomTypeResponse>(roomTypeResult);
        return Ok(response);
    }

    // GET: api/roomtypes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        GetRoomTypeRequest getRoomTypeRequest = new(id);
        var query = _mapper.Map<GetRoomTypeQuery>(getRoomTypeRequest);

        RoomTypeResult roomtypeResult = await _mediator.Send(query);

        var response = _mapper.Map<RoomTypeResponse>(roomtypeResult);

        return Ok(response);
    }

}