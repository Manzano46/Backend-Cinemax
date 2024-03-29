using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Discounts.Common;
using Cinemax.Domain.Discount.Entities;
using MediatR;

namespace Cinemax.Application.Discounts.Commands.Delete;
public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, DiscountResult>
{
    private readonly IDiscountRepository _discountRepository; 

    public DeleteDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;    
    }
    public async Task<DiscountResult> Handle(DeleteDiscountCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_discountRepository.GetById(command.Id) is not Discount discount){
            throw new Exception("Discount not found");
        }
        _discountRepository.Delete(command.Id);
        return new DiscountResult(discount);
    }
}