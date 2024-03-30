using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Discount.ValueObjects;

namespace Cinemax.Domain.Discount.Entities;
public class Discount: Entity<DiscountId>{
    public string Name {get;set;} = null!;

    #pragma warning disable CS8618
    private Discount(){}
    #pragma warning restore CS8618
    private Discount(DiscountId discountId, string name)
        : base(discountId){
            Name = name;
    }

    public static Discount Create(string name){
        return new(DiscountId.CreateUnique(), name);
    }

}