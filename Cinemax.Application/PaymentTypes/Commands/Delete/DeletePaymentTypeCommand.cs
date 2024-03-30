using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Domain.PaymentType.ValueObjects;
using MediatR;

public record DeletePaymentTypeCommand(PaymentTypeId Id) : IRequest<PaymentTypeResult>;
