using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Domain.PaymentType.ValueObjects;
using MediatR;

namespace Cinemax.Application.PaymentTypes.Queries.Get;
public record GetPaymentTypeQuery(
    PaymentTypeId PaymentTypeId
) : IRequest<PaymentTypeResult>;
