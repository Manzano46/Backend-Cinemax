using Cinemax.Application.Discounts.Commands.Create;
using Cinemax.Application.Discounts.Common;
using Cinemax.Application.Discounts.Queries.Get;
using Cinemax.Application.Discounts.Queries.Read;
using Cinemax.Contracts.Discounts;
using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Discount.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("discounts")]
//[Authorize(Roles = "ADMIN")] 

public class DiscountController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public DiscountController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/discounts
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateDiscountRequest createDiscountRequest)
    {
        var command = _mapper.Map<CreateDiscountCommand>(createDiscountRequest);

        DiscountResult discountResult = await _mediator.Send(command);

        var response = _mapper.Map<DiscountResponse>(discountResult);
        return Ok(response);
    }

    // GET: api/discounts
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadDiscountsQuery();

        IEnumerable<DiscountResult> discountResults = await _mediator.Send(command);

        IEnumerable<DiscountResponse> responses = discountResults.Select(DiscountResult => _mapper.Map<DiscountResponse>(DiscountResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/discounts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        DiscountId discountId = DiscountId.Create(new (id));
        var command = new DeleteDiscountCommand(discountId);
        DiscountResult discountResult = await _mediator.Send(command);
        var response = _mapper.Map<DiscountResponse>(discountResult);
        return Ok(response);
    }

    // GET: api/discounts/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(GetDiscountRequest getDiscountRequest)
    {
        var query = _mapper.Map<GetDiscountQuery>(getDiscountRequest);

        DiscountResult DiscountResult = await _mediator.Send(query);

        var response = _mapper.Map<DiscountResponse>(DiscountResult);

        return Ok(response);
    }

    /*
    // PUT: api/Discounts/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCountrieCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/Discounts/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCountrieCommand { Id = id });
        return NoContent();
    }
    */
}