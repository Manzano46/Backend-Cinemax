using Cinemax.Application.Countries.Commands.Create;
using Cinemax.Application.Countries.Common;
using Cinemax.Application.Countries.Queries.Get;
using Cinemax.Application.Countries.Queries.Read;
using Cinemax.Contracts.Countries;
using Cinemax.Domain.Country.Entities;
using Cinemax.Domain.Country.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("countries")]
//[Authorize(Roles = "ADMIN")] 
public class CountryController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CountryController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/countries
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreateCountryRequest createCountryRequest)
    {
        var command = _mapper.Map<CreateCountryCommand>(createCountryRequest);

        CountryResult CountryResult = await _mediator.Send(command);

        var response = _mapper.Map<CountryResponse>(CountryResult);
        return Ok(response);
    }

    // GET: api/countries
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadCountriesQuery();

        IEnumerable<CountryResult> CountryResults = await _mediator.Send(command);

        IEnumerable<CountryResponse> responses = CountryResults.Select(CountryResult => _mapper.Map<CountryResponse>(CountryResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/countries/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        CountryId CountryId = CountryId.Create(new (id));
        var command = new DeleteCountryCommand(CountryId);
        CountryResult CountryResult = await _mediator.Send(command);
        var response = _mapper.Map<CountryResponse>(CountryResult);
        return Ok(response);
    }

    // GET: api/Countries/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        GetCountryRequest getCountryRequest = new(id);
        var query = _mapper.Map<GetCountryQuery>(getCountryRequest);

        CountryResult CountryResult = await _mediator.Send(query);

        var response = _mapper.Map<CountryResponse>(CountryResult);

        return Ok(response);
    }

    // PATCH: api/countries/{id}
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

        var command = new UpdateCountryCommand(id, patchDoc);
        var actorResult = await _mediator.Send(command);

        return Ok(actorResult);
    }
}