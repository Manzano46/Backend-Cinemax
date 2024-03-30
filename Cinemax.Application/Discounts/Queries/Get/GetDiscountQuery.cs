using Cinemax.Application.Discounts.Common;
using Cinemax.Domain.Discount.ValueObjects;
using MediatR;

namespace Cinemax.Application.Discounts.Queries.Get;
public record GetDiscountQuery(
    DiscountId DiscountId
) : IRequest<DiscountResult>;
