using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;

public class LoyaltyPointsDecorator : PriceCalculatorDecorator
{
    private readonly decimal _pointsRate;

    public LoyaltyPointsDecorator(IPriceCalculator inner, decimal pointsRate = 100): base(inner) => _pointsRate = pointsRate;

    public override Price CalculatePrice(Product product)
    {
        var basePrice = _inner.CalculatePrice(product);
        var loyaltyPoints = basePrice.Amount * _pointsRate;
        return new Price(basePrice.Amount, $"{loyaltyPoints:0} pkt.");
    }
}
