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
    public class CustomLabelDecoratorTests
    {
        [Fact]
        public void CalculatePrice_WhenCalledOnProductWithoutLabel_ShouldSuccessfullyAddLabel()
        {
            //Arrange
            var baseProduct = TestProducts.Oven2;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new CustomLabelDecorator(calculator, "Custom Label");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal("Custom Label", decoratedPrice.Label);
        }

        [Fact]
        public void CalculatePrice_WhenCalledAfterOtherLabelDecorator_ShouldOverridePriceLabel()
        {
            //Arrange
            var baseProduct = TestProducts.Oven2;
            IPriceCalculator calculator = new BasePriceCalculator();
            calculator = new LoyaltyPointsDecorator(calculator);
            calculator = new CustomLabelDecorator(calculator, "Custom Label");

            //Act
            var decoratedPrice = calculator.CalculatePrice(baseProduct);

            //Assert
            Assert.Equal("Custom Label", decoratedPrice.Label);
        }

    }
}
