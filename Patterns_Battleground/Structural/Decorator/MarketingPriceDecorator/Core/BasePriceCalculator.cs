namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

public class BasePriceCalculator : IPriceCalculator
{
    public Price CalculatePrice(Product product)
    {
        return new Price(product.BasePrice);
    }
}
