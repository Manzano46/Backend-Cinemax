using Cinemax.Application.Tickets.Commands.Create;
using Cinemax.Application.Tickets.Commands.Delete;
using Cinemax.Application.Tickets.Common;
using Cinemax.Application.Tickets.Queries.Read;
using Cinemax.Contracts.Tickets;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Cinemax.Application.Tickets.Queries.Get;
using Cinemax.Application.Tickets.Commands.Confirm;
using Cinemax.Domain.ProjectionAggregate.ValueObjects;
using Cinemax.Application.Tickets.Queries.GetReserved;
using Cinemax.Application.Tickets.Queries.GetReservedByUser;
using Cinemax.Domain.User.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Cinemax.Application.Tickets.Queries.GetTopRoomCounts;
using Cinemax.Application.Extras.Queries.Validate;
using Microsoft.AspNetCore.JsonPatch;
using Cinemax.Application.Tickets.Commands.Update;
using Cinemax.Application.Tickets.Queries.GetBestSection;
using Cinemax.Domain.TicketAggregate.ValueObjects;
using DinkToPdf;
using Cinemax.Infrastructure;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;
using Cinemax.Application.Tickets.Queries.Refund;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("tickets")]

public class TicketController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TicketController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/tickets/create
    [HttpPost("create")]
   // [Authorize(Roles = "ADMIN,USER")] 
    public async Task<IActionResult> Create(CreateTicketsRequest createTicketsRequest)
    {
        List<TicketResponse> responses = new List<TicketResponse>();
        foreach(var createTicketRequest in createTicketsRequest.CreateTicketsRequests){
            var command = _mapper.Map<CreateTicketCommand>(createTicketRequest);

            CreateTicketCommand command1 = new(command.SeatId, command.UserId, command.ProjectionId, DateTime.UtcNow);

            TicketResult TicketResult = await _mediator.Send(command1);

            var response = _mapper.Map<TicketResponse>(TicketResult);
            responses.Add(response);

        }

        return Ok(responses);
    }

    // POST: api/tickets/confirm/
    [HttpPost("confirm/{paymentTypeid}")]
    //[Authorize(Roles = "ADMIN,USER")] 
    public async Task<IActionResult> Confirm(ConfirmTicketsRequest confirmTicketsRequest, string paymentTypeid)
    {
        var pdfTools = new PdfTools();
        var _converter = new SynchronizedConverter(pdfTools);
        var ticketProvider = new TicketProvider(_converter);
        var query = new ValidateQuery(confirmTicketsRequest.ConfirmTicketsRequests.Count(), confirmTicketsRequest.ConfirmTicketsRequests[0].UserId, paymentTypeid);
        await _mediator.Send(query);

        List<Tuple<TicketResponse,byte[]>> responses = new List<Tuple<TicketResponse,byte[]>>();
        foreach(var confirmTicketRequest in confirmTicketsRequest.ConfirmTicketsRequests){
            var command = _mapper.Map<ConfirmTicketCommand>(confirmTicketRequest);

            ConfirmTicketCommand command1 = new(command.SeatId, command.UserId, command.ProjectionId, DateTime.UtcNow, PaymentTypeId.Create(new(paymentTypeid)));

            TicketResult TicketResult = await _mediator.Send(command1);

            var response = _mapper.Map<TicketResponse>(TicketResult);

            byte[] ticketPdf = ticketProvider.GenerateTicket(@"..\..\..\Cinemax.Infrastructure\Services\TicketProvider\TicketTemplate.html", @"..\..\..\Cinemax.Infrastructure\Services\TicketProvider\cinemax.png", TicketResult.Ticket);


            responses.Add(new Tuple<TicketResponse,byte[]>(response,ticketPdf));

        }

        // poner puntos
        

        return Ok(responses);
    }

    // GET: api/tickets
    [HttpGet]
    //[Authorize(Roles = "ADMIN")] 
    public async Task<IActionResult> Read()
    {
        var query = new ReadTicketQuery();

        IEnumerable<TicketResult> TicketResults = await _mediator.Send(query);

        IEnumerable<TicketResponse> responses = TicketResults.Select(_mapper.Map<TicketResponse>);
        
        return Ok(responses);
    }

    // DELETE: api/Tickets/{id}
    [HttpDelete("{id}")]
    //[Authorize(Roles = "ADMIN")] 
    public async Task<IActionResult> Delete(string id)
    {
        DeleteTicketRequest deleteTicketRequest = new(id);
        var command = _mapper.Map<DeleteTicketCommand>(deleteTicketRequest);

        TicketResult TicketResult = await _mediator.Send(command);

        var response = _mapper.Map<TicketResponse>(TicketResult);

        return Ok(response);
    }

    // GET: api/Tickets/{id}
    [HttpGet("{id}")]
    //[Authorize(Roles = "ADMIN")] 
    public async Task<IActionResult> Get(string id)
    {
        GetTicketRequest getTicketRequest = new(id);
        var query = _mapper.Map<GetTicketQuery>(getTicketRequest);

        TicketResult TicketResult = await _mediator.Send(query);

        var response = _mapper.Map<TicketResponse>(TicketResult);

        return Ok(response);
    }

    // GET: api/tickets/byprojection/{projectionid}/
    [HttpGet("byprojection/{id}")]
    //[Authorize(Roles = "ADMIN,USER")] 
    public async Task<IActionResult> GetByProjection(string id)
    {
        var query = new GetByProjectionQuery(ProjectionId.Create(new(id)));

        IEnumerable<TicketResult> TicketResults = await _mediator.Send(query);

        IEnumerable<TicketResponse> responses = TicketResults.Select(_mapper.Map<TicketResponse>);
        
        return Ok(responses);
    }

    // GET: api/tickets/reserved
    [HttpGet("reserved")]
    //[Authorize(Roles = "ADMIN,USER")] 
    public async Task<IActionResult> GetReserved()
    {
        var query = new GetReservedQuery();

        IEnumerable<TicketResult> TicketResults = await _mediator.Send(query);

        IEnumerable<TicketResponse> responses = TicketResults.Select(_mapper.Map<TicketResponse>);
        
        return Ok(responses);
    }

    // GET: api/tickets/reservedbyuser/{id}
    [HttpGet("reservedbyuser/{id}")]
    //[Authorize(Roles = "ADMIN,USER")] 
    public async Task<IActionResult> GetReserved(string id)
    {
        var query = new GetReservedByUserQuery(UserId.Create(new(id)));

        IEnumerable<TicketResult> TicketResults = await _mediator.Send(query);

        IEnumerable<TicketResponse> responses = TicketResults.Select(_mapper.Map<TicketResponse>);
        
        return Ok(responses);
    }

    // GET: api/tickets/roomCounts/{startDate}/{endDate}/{limit}
    [HttpGet("roomCounts/{startDate}/{endDate}/{limit}")]
    //[Authorize(Roles = "ADMIN,USER")] 
    public async Task<IActionResult> GetTopRoomCounts(DateTime startDate,DateTime endDate,int limit)
    {
        var roomCounts = await _mediator.Send(new GetTopRoomCountsQuery(startDate,endDate,limit));
        return Ok(roomCounts);
    }

    [HttpGet("sections")]
    //[Authorize(Roles = "ADMIN,USER")] 
    public async Task<IActionResult> GetBestSections()
    {
        var query = new GetBestSectionQuery();
        var bestSections = await _mediator.Send(query);
        return Ok(bestSections);
    }


    // PATCH: api/actors/{id}
    [HttpPatch("{id}")]
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

        var command = new UpdateTicketCommand(id, patchDoc);
        var actorResult = await _mediator.Send(command);

        return Ok(actorResult);
    }

    // POST: api/tickets/refund/{id}
    [HttpPost("refund/{id}")]
    //[Authorize(Roles = "ADMIN,USER")]
    public async Task<IActionResult> Refund(string id)
    {
        var ticketId = TicketId.Create(new(id));
        var command = new RefundTicketQuery(ticketId);
        var TicketResult = await _mediator.Send(command);

        var response = _mapper.Map<TicketResponse>(TicketResult);

        return Ok(response);
    }
}