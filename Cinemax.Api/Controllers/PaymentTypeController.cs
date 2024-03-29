using Cinemax.Application.PaymentTypes.Commands.Create;
using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Application.PaymentTypes.Queries.Read;
using Cinemax.Contracts.PaymentTypes;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinemax.Api.Controllers;

[ApiController]
[Route("paymentTypes")]

public class PaymentTypeController : ControllerBase{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PaymentTypeController(IMediator mediator, IMapper mapper){
        _mediator = mediator;
        _mapper = mapper;
    } 

    // POST: api/paymentTypes
    [HttpPost]
    //[Authorize] 
    public async Task<IActionResult> Create(CreatePaymentTypeRequest createPaymentTypeRequest)
    {
        var command = _mapper.Map<CreatePaymentTypeCommand>(createPaymentTypeRequest);

        PaymentTypeResult paymentTypeResult = await _mediator.Send(command);

        var response = _mapper.Map<PaymentTypeResponse>(paymentTypeResult);
        return Ok(response);
    }

    // GET: api/paymentTypes
    [HttpGet]
    public async Task<IActionResult> Read()
    {
        var command = new ReadPaymentTypesQuery();

        IEnumerable<PaymentTypeResult> paymentTypeResults = await _mediator.Send(command);

        IEnumerable<PaymentTypeResponse> responses = paymentTypeResults.Select(PaymentTypeResult => _mapper.Map<PaymentTypeResponse>(PaymentTypeResult));
        
        return Ok(responses);
    }


    
    // DELETE: api/paymentTypes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        PaymentTypeId paymentTypeId = PaymentTypeId.Create(new (id));
        var command = new DeletePaymentTypeCommand(paymentTypeId);
        PaymentTypeResult paymentTypeResult = await _mediator.Send(command);
        var response = _mapper.Map<PaymentTypeResponse>(paymentTypeResult);
        return Ok(response);
    }

    /*
    // PUT: api/PaymentTypes/{id}
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

    // DELETE: api/PaymentTypes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCountrieCommand { Id = id });
        return NoContent();
    }
    */
}