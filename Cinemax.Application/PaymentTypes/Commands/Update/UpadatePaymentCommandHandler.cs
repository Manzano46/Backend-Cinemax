using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Domain.PaymentType.Entities;
using MediatR;
using Cinemax.Domain.PaymentType.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.PaymentTypes.Commands.Update;
public class UpdatePaymentTypeCommandHandler : IRequestHandler<UpdatePaymentTypeCommand, PaymentTypeResult>
{
    private readonly IPaymentTypeRepository _PaymentTypeRepository; 

    public UpdatePaymentTypeCommandHandler(IPaymentTypeRepository PaymentTypeRepository)
    {
        _PaymentTypeRepository = PaymentTypeRepository;    
    }
    public async Task<PaymentTypeResult> Handle(UpdatePaymentTypeCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var paymentTypeId = PaymentTypeId.Create(new (command.Id));
        var PaymentType = _PaymentTypeRepository.GetById(paymentTypeId);

        if (PaymentType is null)
        {
            throw new Exception("PaymentType with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(PaymentType);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the PaymentType", ex);
        }
        
        _PaymentTypeRepository.Update(PaymentType);

        return new PaymentTypeResult(PaymentType);
    }
}