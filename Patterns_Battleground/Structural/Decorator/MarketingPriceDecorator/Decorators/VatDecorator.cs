using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;

public class VatDecorator : PriceCalculatorDecorator
{
    private readonly decimal _vatRate;

    public VatDecorator(IPriceCalculator inner, decimal vatRate) : base(inner)
    {
        if(vatRate < 0) throw new ArgumentOutOfRangeException(nameof(vatRate), "Vat rate cannot be negative");
        _vatRate = vatRate;
    }

    public override Price CalculatePrice(Product product)
    {
        var basePrice = _inner.CalculatePrice(product);
        return new Price(basePrice.Amount * (1 + _vatRate), basePrice.Label);
    }
}
