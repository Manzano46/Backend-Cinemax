using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Discount.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class DiscountRepository : IDiscountRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public DiscountRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(Discount discount)
    {
        _cinemaxDbContext.Discounts.Add(discount);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<Discount> GetAllDiscounts()
    {
        return _cinemaxDbContext.Discounts;
    }

    public Discount? GetByName(string name)
    {
        return _cinemaxDbContext.Discounts.SingleOrDefault(m => m.Name == name);
    }
    
       public Discount? GetById(DiscountId DiscountId)
    {
        return _cinemaxDbContext.Discounts.SingleOrDefault(m => m.Id == DiscountId);
    }
    
    public void Delete(DiscountId id)
    {
        var discount = _cinemaxDbContext.Discounts.SingleOrDefault(m => m.Id == id);
        if (discount is not null)
        {
            _cinemaxDbContext.Discounts.Remove(discount);
            _cinemaxDbContext.SaveChanges();
        }
    }


}
