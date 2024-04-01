using Cinemax.Domain.Common.Models;
using Cinemax.Domain.PaymentType.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;

namespace Cinemax.Domain.PaymentType.Entities;
public class PaymentType: Entity<PaymentTypeId>{
    public string Name {get;set;} = null!;
    public virtual ICollection<Ticket> Tickets {get; set;} = null!;

    #pragma warning disable CS8618
    private PaymentType(){}
    #pragma warning restore CS8618
    private PaymentType(PaymentTypeId paymentTypeId, string name, List<Ticket> tickets = null!)
        : base(paymentTypeId){
            Name = name;
            Tickets = tickets ?? [];
    }

    public static PaymentType Create(string name, List<Ticket> tickets = null!){
        return new(PaymentTypeId.CreateUnique(), name, tickets);
    }

}