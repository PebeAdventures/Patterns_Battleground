using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;

public class CustomLabelDecorator : PriceCalculatorDecorator
{
    private readonly string _label;

    public CustomLabelDecorator(IPriceCalculator inner, string label) : base(inner) => _label = label;

    public override Price CalculatePrice(Product product)
    {
        var basePrice = _inner.CalculatePrice(product);
        return new Price(basePrice.Amount, Label: _label);
    }
}
