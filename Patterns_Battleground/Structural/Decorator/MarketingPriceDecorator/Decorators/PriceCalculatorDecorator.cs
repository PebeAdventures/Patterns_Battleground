using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;

public abstract class PriceCalculatorDecorator : IPriceCalculator
{
    protected readonly IPriceCalculator _inner;

    protected PriceCalculatorDecorator(IPriceCalculator inner)
    {
        _inner = inner;
    }

    public abstract Price CalculatePrice(Product product);
}
