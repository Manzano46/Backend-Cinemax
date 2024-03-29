using Cinemax.Application.Common.Interfaces.Persistence;
using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;

namespace Cinemax.Infrastructure.Persistence.Repositories;
public class PaymentTypeRepository : IPaymentTypeRepository{
    private readonly CinemaxDbContext _cinemaxDbContext;

    public PaymentTypeRepository(CinemaxDbContext cinemaxDbContext){
        _cinemaxDbContext = cinemaxDbContext;
    }

    public void Add(PaymentType paymentType)
    {
        _cinemaxDbContext.PaymentTypes.Add(paymentType);
        _cinemaxDbContext.SaveChanges();
    }

    public IEnumerable<PaymentType> GetAllPaymentTypes()
    {
        return _cinemaxDbContext.PaymentTypes;
    }

    public PaymentType? GetByName(string name)
    {
        return _cinemaxDbContext.PaymentTypes.SingleOrDefault(m => m.Name == name);
    }
    
       public PaymentType? GetById(PaymentTypeId paymentTypeId)
    {
        return _cinemaxDbContext.PaymentTypes.SingleOrDefault(m => m.Id == paymentTypeId);
    }
    
    public void Delete(PaymentTypeId id)
    {
        var paymentType = _cinemaxDbContext.PaymentTypes.SingleOrDefault(m => m.Id == id);
        if (paymentType is not null)
        {
            _cinemaxDbContext.PaymentTypes.Remove(paymentType);
            _cinemaxDbContext.SaveChanges();
        }
    }


}
