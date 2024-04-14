using Cinemax.Domain.PaymentType.Entities;
using Cinemax.Domain.PaymentType.ValueObjects;

namespace Cinemax.Application.Common.Interfaces.Persistence;
public interface IPaymentTypeRepository : IRepository<PaymentType, PaymentTypeId>{
    PaymentType? GetByName(string name);    
}
