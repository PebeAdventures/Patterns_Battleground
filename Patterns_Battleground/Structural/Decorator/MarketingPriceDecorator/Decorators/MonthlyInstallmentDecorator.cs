using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

namespace Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;

public class MonthlyInstallmentDecorator : PriceCalculatorDecorator
{
    private readonly int _numberOfInstallments;
    private readonly decimal _interestRate;
    public MonthlyInstallmentDecorator(IPriceCalculator inner, int numberOfInstallments, decimal interestRate = 0) : base(inner)
    {
        _numberOfInstallments = numberOfInstallments;
        _interestRate = interestRate;
    }
    public override Price CalculatePrice(Product product)
    {
        var basePrice = _inner.CalculatePrice(product);
        var totalPrice = basePrice.Amount * (1 + _interestRate);
        var installmentAmount = totalPrice / _numberOfInstallments;
        return new Price(basePrice.Amount, $"{installmentAmount:0.00} zł/m przez {_numberOfInstallments} mc.");
    }
}
