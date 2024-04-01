namespace Cinemax.Contracts.Discounts;

public record DiscountResponse(
    string Id,
    string Name,
    float Percentage
);