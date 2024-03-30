using Cinemax.Application.PaymentTypes.Common;
using MediatR;

namespace Cinemax.Application.PaymentTypes.Queries.Read;
public record ReadPaymentTypesQuery(
    
) : IRequest<IEnumerable<PaymentTypeResult>>;
