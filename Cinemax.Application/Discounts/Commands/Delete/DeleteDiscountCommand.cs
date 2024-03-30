using Cinemax.Application.Discounts.Common;
using Cinemax.Domain.Discount.ValueObjects;
using MediatR;

public record DeleteDiscountCommand(DiscountId Id) : IRequest<DiscountResult>;
