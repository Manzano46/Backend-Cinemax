using Cinemax.Application.PaymentTypes.Common;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

public record UpdatePaymentTypeCommand(string Id,  JsonPatchDocument patchDoc) : IRequest<PaymentTypeResult>;
