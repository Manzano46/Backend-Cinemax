using Cinemax.Infrastructure.Services;
using Cinemax.Application.Common.Interfaces.Services;
using Cinemax.Contracts.Ticket;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("tickets")]

public class TicketController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ITicketProvider _ticketProvider;

    public TicketController(IMediator mediator, IMapper mapper, ITicketProvider ticketProvider){
        _mediator = mediator;
        _mapper = mapper;
        _ticketProvider = ticketProvider;
    } 

    // GET: api/tickets
    [HttpGet]
    public async Task<IActionResult> Get(GetTicketRequest getTicketRequest)
    {
        byte[] ticket =  await _ticketProvider.GeneratePdfFromHtmlFile(getTicketRequest.room, getTicketRequest.seat, getTicketRequest.date, getTicketRequest.time, getTicketRequest.id, getTicketRequest.movie, getTicketRequest.price, "qr.png", "cinemaxLogo.png", "backdrop.png");

        return File(ticket, "application/pdf");
    }
    //Example request:
    //GET: 127.0.0.1:7141/tickets?room=1&seat=1&date=2022-01-01&time=12:00&id=1&movie=movie1&price=10.00
    
}
