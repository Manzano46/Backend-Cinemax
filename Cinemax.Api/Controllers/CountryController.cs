using Cinemax.Application.Countries.Commands.Create;
using Cinemax.Application.Countries.Common;
using Cinemax.Application.Countries.Queries.Read;
using Cinemax.Contracts.Countries;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("countries")]

public class CountryController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CountryController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/Countries
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateCountryRequest createCountryRequest)
    {
        var command = _mapper.Map<CreateCountryCommand>(createCountryRequest);

        CountryResult CountryResult = await _mediator.Send(command);

        var response = _mapper.Map<CountryResponse>(CountryResult);
        return Ok(response);
    }

    // GET: api/Countries
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadCountriesQuery();

        IEnumerable<CountryResult> CountryResults = await _mediator.Send(command);

        IEnumerable<CountryResponse> responses = CountryResults.Select(CountryResult => _mapper.Map<CountryResponse>(CountryResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/Countries/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        CountryId CountryId = CountryId.Create(new (id));
        var command = new DeleteCountryCommand(CountryId);
        CountryResult CountryResult = await _mediator.Send(command);
        var response = _mapper.Map<CountryResponse>(CountryResult);
        return Ok(response);
    }

    /*
    // PUT: api/Countries/{id}
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

    // DELETE: api/Countries/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCountrieCommand { Id = id });
        return NoContent();
    }
    */
}