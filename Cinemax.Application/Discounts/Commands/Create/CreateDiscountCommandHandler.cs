using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Discounts.Common;
using Cinemax.Domain.Discount.Entities;
using MediatR;

namespace Cinemax.Application.Discounts.Commands.Create;
public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, DiscountResult>
{
    private readonly IDiscountRepository _discountRepository; 

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;    
    }
    public async Task<DiscountResult> Handle(CreateDiscountCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if(_discountRepository.GetByName(command.Name) is not null){
            throw new Exception("Discount with given name alredy exists");
        }

        Discount discount = Discount.Create(
            command.Name
        );

        _discountRepository.Add(discount);

        return new DiscountResult(discount);
    }

}
