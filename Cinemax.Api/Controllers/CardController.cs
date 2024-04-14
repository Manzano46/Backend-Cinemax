using Cinemax.Application.Cards.Commands.Create;
using Cinemax.Application.Cards.Common;
using Cinemax.Application.Cards.Queries.Read;
using Cinemax.Contracts.Cards;
using Cinemax.Domain.Card.Entities;
using Cinemax.Domain.Card.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("cards")]
//[Authorize(Roles = "ADMIN")] 
public class CardController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CardController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/cards
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateCardRequest createCardRequest)
    {
        var command = _mapper.Map<CreateCardCommand>(createCardRequest);

        CardResult CardResult = await _mediator.Send(command);

        var response = _mapper.Map<CardResponse>(CardResult);
        return Ok(response);
    }

    

    // GET: api/cards
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadCardsQuery();

        IEnumerable<CardResult> CardResults = await _mediator.Send(command);

        IEnumerable<CardResponse> responses = CardResults.Select(CardResult => _mapper.Map<CardResponse>(CardResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/cards/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        CardId CardId = CardId.Create(long.Parse(id));
        var command = new DeleteCardCommand(CardId);
        CardResult CardResult = await _mediator.Send(command);
        var response = _mapper.Map<CardResponse>(CardResult);
        return Ok(response);
    }

    // PATCH: api/cards/{id}
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

        var command = new UpdateCardCommand(id, patchDoc);
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}