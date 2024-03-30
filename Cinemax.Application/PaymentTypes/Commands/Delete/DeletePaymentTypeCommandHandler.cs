using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Domain.PaymentType.Entities;
using MediatR;

namespace Cinemax.Application.PaymentTypes.Commands.Delete;
public class DeletePaymentTypeCommandHandler : IRequestHandler<DeletePaymentTypeCommand, PaymentTypeResult>
{
    private readonly IPaymentTypeRepository _paymentTypeRepository; 

    public DeletePaymentTypeCommandHandler(IPaymentTypeRepository paymentTypeRepository)
    {
        _paymentTypeRepository = paymentTypeRepository;    
    }
    public async Task<PaymentTypeResult> Handle(DeletePaymentTypeCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_paymentTypeRepository.GetById(command.Id) is not PaymentType paymentType){
            throw new Exception("PaymentType not found");
        }
        _paymentTypeRepository.Delete(command.Id);
        return new PaymentTypeResult(paymentType);
    }
}