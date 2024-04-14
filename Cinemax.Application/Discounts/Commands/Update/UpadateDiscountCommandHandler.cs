using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Application.Discounts.Common;
using Cinemax.Domain.Discount.Entities;
using MediatR;
using Cinemax.Domain.Discount.ValueObjects;
using Newtonsoft.Json;

namespace Cinemax.Application.Discounts.Commands.Update;
public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, DiscountResult>
{
    private readonly IDiscountRepository _DiscountRepository; 

    public UpdateDiscountCommandHandler(IDiscountRepository DiscountRepository)
    {
        _DiscountRepository = DiscountRepository;    
    }
    public async Task<DiscountResult> Handle(UpdateDiscountCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var discountId = DiscountId.Create(new (command.Id));
        var Discount = _DiscountRepository.GetById(discountId);

        if (Discount is null)
        {
            throw new Exception("Discount with given Id does not exist");
        }

        try
        {
            command.patchDoc.ApplyTo(Discount);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while updating the Discount", ex);
        }
        
        _DiscountRepository.Update(Discount);

        return new DiscountResult(Discount);
    }
}