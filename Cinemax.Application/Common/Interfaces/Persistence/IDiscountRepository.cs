using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Discount.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IDiscountRepository{
    Discount? GetByName(string name);
    Discount? GetById(DiscountId discountId);
    void Add(Discount discount);
    void Delete(DiscountId discount);
    IEnumerable<Discount> GetAllDiscounts();
}
