using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Discount.ValueObjects;
using Cinemax.Domain.TicketAggregate.Entities;

namespace Cinemax.Domain.Discount.Entities;
public class Discount: Entity<DiscountId>{
    public string Name {get;set;} = null!;
    public ICollection<Ticket> Tickets {get; set;} = null!;
    public float Percentage {get; set;}
    
    #pragma warning disable CS8618
    private Discount(){}
    #pragma warning restore CS8618
    private Discount(DiscountId discountId, string name, float percentage ,List<Ticket> tickets = null!)
        : base(discountId){
            Name = name;
            Percentage = percentage;
            Tickets = tickets ?? [];
    }

    public static Discount Create(string name, float percentage, List<Ticket> tickets = null!){
        return new(DiscountId.CreateUnique(), name, percentage, tickets);
    }

}