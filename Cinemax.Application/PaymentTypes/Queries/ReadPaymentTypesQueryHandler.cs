using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Application.PaymentTypes.Queries.Read;
using MediatR;

namespace Cinemax.Application.PaymentTypes.Query.Read;
public class ReadPaymentTypesQueryHandler : IRequestHandler<ReadPaymentTypesQuery, IEnumerable<PaymentTypeResult>>
{
    private readonly IPaymentTypeRepository _paymentTypeRepository; 

    public ReadPaymentTypesQueryHandler(IPaymentTypeRepository paymentTypeRepository)
    {
        _paymentTypeRepository = paymentTypeRepository;    
    }
    public async Task<IEnumerable<PaymentTypeResult>> Handle(ReadPaymentTypesQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _paymentTypeRepository.GetAll().Select(x => new PaymentTypeResult(x));
    }
}
