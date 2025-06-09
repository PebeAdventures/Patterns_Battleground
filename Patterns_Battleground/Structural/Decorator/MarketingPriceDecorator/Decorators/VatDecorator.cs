using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;

public class VatDecorator : PriceCalculatorDecorator
{
    private readonly decimal _vatRate;

    public VatDecorator(IPriceCalculator inner, decimal vatRate): base(inner) => _vatRate = vatRate;

    public override Price CalculatePrice(Product product)
    {
        var basePrice = _inner.CalculatePrice(product);
        return new Price(basePrice.Amount * _vatRate);
    }
}
