using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Discount.ValueObjects;

namespace Cinemax.Domain.Discount.Entities;
public class Discount: Entity<DiscountId>{
    public string Name {get;set;} = null!;
    public float Percentage {get;set;}

    #pragma warning disable CS8618
    private Discount(){}
    #pragma warning restore CS8618
    private Discount(DiscountId discountId, string name,float percentage)
        : base(discountId){
            Name = name;
            Percentage = percentage;
    }

    public static Discount Create(string name,float percentage){
        return new(DiscountId.CreateUnique(), name,percentage);
    }

}