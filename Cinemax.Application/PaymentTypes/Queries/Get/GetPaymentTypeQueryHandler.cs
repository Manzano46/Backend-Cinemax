using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.PaymentTypes.Common;
using MediatR;

namespace Cinemax.Application.PaymentTypes.Queries.Get;
public class GetPaymentTypeQueryHandler : IRequestHandler<GetPaymentTypeQuery, PaymentTypeResult>
{
    private readonly IPaymentTypeRepository _PaymentTypeRepository;

    public GetPaymentTypeQueryHandler(IPaymentTypeRepository PaymentTypeRepository)
    {
        _PaymentTypeRepository = PaymentTypeRepository;
    }
    public async Task<PaymentTypeResult> Handle(GetPaymentTypeQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_PaymentTypeRepository.GetById(command.PaymentTypeId)!);
    }
}
