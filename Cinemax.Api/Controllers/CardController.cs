using Cinemax.Application.Cards.Commands.Create;
using Cinemax.Application.Cards.Common;
using Cinemax.Application.Cards.Queries.Read;
using Cinemax.Contracts.Cards;
using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("Cards")]

public class CardController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CardController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/Cards
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateCardRequest createCardRequest)
    {
        var command = _mapper.Map<CreateCardCommand>(createCardRequest);

        CardResult CardResult = await _mediator.Send(command);

        var response = _mapper.Map<CardResponse>(CardResult);
        return Ok(response);
    }

    // GET: api/Cards
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadCardsQuery();

        IEnumerable<CardResult> CardResults = await _mediator.Send(command);

        IEnumerable<CardResponse> responses = CardResults.Select(CardResult => _mapper.Map<CardResponse>(CardResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/Cards/{number}
    [HttpDelete("{number}")]
    public async Task<IActionResult> Delete(string number)
    {
        CardNumber CardNumber = CardNumber.Create(new (number));
        var command = new DeleteCardCommand(CardNumber);
        CardResult CardResult = await _mediator.Send(command);
        var response = _mapper.Map<CardResponse>(CardResult);
        return Ok(response);
    }

    /*
    // PUT: api/Cards/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCardCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/Cards/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCardCommand { Id = id });
        return NoContent();
    }
    */

}