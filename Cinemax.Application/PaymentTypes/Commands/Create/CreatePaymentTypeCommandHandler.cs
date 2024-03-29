using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Domain.PaymentType.Entities;
using MediatR;

namespace Cinemax.Application.PaymentTypes.Commands.Create;
public class CreatePaymentTypeCommandHandler : IRequestHandler<CreatePaymentTypeCommand, PaymentTypeResult>
{
    private readonly IPaymentTypeRepository _paymentTypeRepository; 

    public CreatePaymentTypeCommandHandler(IPaymentTypeRepository paymentTypeRepository)
    {
        _paymentTypeRepository = paymentTypeRepository;    
    }
    public async Task<PaymentTypeResult> Handle(CreatePaymentTypeCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_paymentTypeRepository.GetByName(command.Name) is not null){
            throw new Exception("PaymentType with given name alredy exists");
        }

        PaymentType paymentType = PaymentType.Create(
            command.Name
        );

        _paymentTypeRepository.Add(paymentType);

        return new PaymentTypeResult(paymentType);
    }

}
