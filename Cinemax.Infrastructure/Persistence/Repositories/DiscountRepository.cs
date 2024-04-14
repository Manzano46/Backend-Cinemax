using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.Discount.Entities;
using Cinemax.Domain.Discount.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class DiscountRepository : Repository<Discount,DiscountId>, IDiscountRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;
    public DiscountRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext)   {
        _cinemaxDbContext = cinemaxDbContext;
    }

    public Discount? GetByName(string name)
    {
        return _cinemaxDbContext.Discounts.SingleOrDefault(d => d.Name == name);
    }
}
