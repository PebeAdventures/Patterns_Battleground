using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Decorators;
using Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator.Mock;

namespace Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator
{
    public class CompositeDecoratorsTests
    {
        [Fact]
        public void CalculatePrice_WithVatAndLoyalty_ShouldReturnCorrectValue()
        {
            //Arrange
            var baseProduct = TestProducts.Toy2;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new VatDecorator(calculator, 0.23m);
            calculator = new LoyaltyPointsDecorator(calculator, 100);
            var expectedPrice = new Price(12.3m, "1230 pkt.");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
            Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
        }

        [Fact]
        public void CalculatePrice_WithMonthlyAndVat_ShouldReturnCorrectValue()
        {
            //Arrange
            var baseProduct = TestProducts.Toy2;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new VatDecorator(calculator, 0.23m);
            calculator = new MonthlyInstallmentDecorator(calculator,24);
            var expectedPrice = new Price(12.3m, "0,51 zł/m przez 24 mc.");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
            Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
        }

        [Fact]
        public void CalculatePrice_WithMonthlyAndCustomLabel_ShouldSuccesfullyOverrideLabel()
        {
            //Arrange
            var baseProduct = TestProducts.Toy2;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new MonthlyInstallmentDecorator(calculator, 24);
            calculator = new CustomLabelDecorator(calculator, "testLabel");
            var expectedPrice = new Price(baseProduct.BasePrice, "testLabel");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
            Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
        }

        [Fact]
        public void CalculatePrice_WithLoyaltyThenVat_ShouldReturnCorrectValue()
        {
            //Arrange
            var baseProduct = TestProducts.Toy2;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new LoyaltyPointsDecorator(calculator, 100);
            calculator = new VatDecorator(calculator, 0.23m);
            var expectedPrice = new Price(12.3m, "1230 pkt.");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal(expectedPrice.Amount, decoratedPrice.Amount);
            Assert.Equal(expectedPrice.Label, decoratedPrice.Label);
        }
    }
}
