using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IPaymentTypeRepository{
    PaymentType? GetByName(string name);
    PaymentType? GetById(PaymentTypeId paymentTypeId);
    void Add(PaymentType paymentType);
    void Delete(PaymentTypeId paymentType);
    IEnumerable<PaymentType> GetAllPaymentTypes();
}
