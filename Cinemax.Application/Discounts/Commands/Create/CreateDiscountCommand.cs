using Cinemax.Application.Discounts.Common;
using Cinemax.Domain.Discount.ValueObjects;
using MediatR;

namespace Cinemax.Application.Discounts.Commands.Create;
public record CreateDiscountCommand(
    string Name,
    float Percentage
) : IRequest<DiscountResult>;

