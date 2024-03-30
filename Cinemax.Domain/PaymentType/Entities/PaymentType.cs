using Cinemax.Domain.Common.Models;
using Cinemax.Domain.PaymentType.ValueObjects;

namespace Cinemax.Domain.PaymentType.Entities;
public class PaymentType: Entity<PaymentTypeId>{
    public string Name {get;set;} = null!;

    #pragma warning disable CS8618
    private PaymentType(){}
    #pragma warning restore CS8618
    private PaymentType(PaymentTypeId paymentTypeId, string name)
        : base(paymentTypeId){
            Name = name;
    }

    public static PaymentType Create(string name){
        return new(PaymentTypeId.CreateUnique(), name);
    }

}