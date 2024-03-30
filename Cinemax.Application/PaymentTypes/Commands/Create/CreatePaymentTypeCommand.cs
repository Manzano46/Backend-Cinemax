using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Domain.PaymentType.ValueObjects;
using MediatR;

namespace Cinemax.Application.PaymentTypes.Commands.Create;
public record CreatePaymentTypeCommand(
    string Name
) : IRequest<PaymentTypeResult>;

