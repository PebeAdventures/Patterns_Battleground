namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core
{
    public interface IPriceCalculator
    {
        Price CalculatePrice(Product product);
    }
}
