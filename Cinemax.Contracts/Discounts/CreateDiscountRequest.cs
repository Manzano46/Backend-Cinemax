namespace Cinemax.Contracts.Discounts
{
    public record CreateDiscountRequest(
        string Name,
        float Percentage
    );
}
