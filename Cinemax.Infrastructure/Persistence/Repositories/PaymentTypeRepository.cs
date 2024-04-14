using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class PaymentTypeRepository : Repository<PaymentType, PaymentTypeId>, IPaymentTypeRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public PaymentTypeRepository(CinemaxDbContext cinemaxDbContext) : base(cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public PaymentType? GetByName(string name)
    {
        return _cinemaxDbContext.PaymentTypes.SingleOrDefault(pt => pt.Name == name);
    }
}
