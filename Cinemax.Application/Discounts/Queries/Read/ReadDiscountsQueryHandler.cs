using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Discounts.Common;
using Cinemax.Application.Discounts.Queries.Read;
using MediatR;

namespace Cinemax.Application.Discounts.Query.Read;
public class ReadDiscountsQueryHandler : IRequestHandler<ReadDiscountsQuery, IEnumerable<DiscountResult>>
{
    private readonly IDiscountRepository _discountRepository; 

    public ReadDiscountsQueryHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;    
    }
    public async Task<IEnumerable<DiscountResult>> Handle(ReadDiscountsQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _discountRepository.GetAll().Select(x => new DiscountResult(x));
    }
}
