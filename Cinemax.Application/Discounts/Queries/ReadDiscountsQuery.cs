using Cinemax.Application.Discounts.Common;
using MediatR;

namespace Cinemax.Application.Discounts.Queries.Read;
public record ReadDiscountsQuery(
    
) : IRequest<IEnumerable<DiscountResult>>;
