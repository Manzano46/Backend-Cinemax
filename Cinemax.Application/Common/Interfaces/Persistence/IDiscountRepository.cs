using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Discount.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IDiscountRepository : IRepository<Discount, DiscountId>{
    Discount? GetByName(string name);
}
