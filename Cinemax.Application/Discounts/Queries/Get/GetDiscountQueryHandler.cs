using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Discounts.Common;
using MediatR;

namespace Cinemax.Application.Discounts.Queries.Get;
public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, DiscountResult>
{
    private readonly IDiscountRepository _DiscountRepository;

    public GetDiscountQueryHandler(IDiscountRepository DiscountRepository)
    {
        _DiscountRepository = DiscountRepository;
    }
    public async Task<DiscountResult> Handle(GetDiscountQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new(_DiscountRepository.GetById(command.DiscountId)!);
    }
}
