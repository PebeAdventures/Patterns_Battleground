using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;
using Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator.Mock;

namespace Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator
{
    public class BasePriceCalculatorTests
    {

        [Fact]
        public void CalculatePrice_WhenCalled_ShouldReturnCorrectProductPrice() 
        {
            //Arrange
            var product = TestProducts.Console1;
            var basePriceCalculator = new BasePriceCalculator();
            var baseProductPrice = product.BasePrice;

            //Act
            var calculatedProductPrice = basePriceCalculator.CalculatePrice(product);

            //Assert
            Assert.Equal(baseProductPrice, calculatedProductPrice.Amount);
        }

        [Fact]
        public void CalculatePrice_WhenCalledWithNegativePrice_ShouldReturnCorrectProductPrice()
        {
            //Arrange
            var product = new Product("test", -10m);
            var basePriceCalculator = new BasePriceCalculator();
            var baseProductPrice = product.BasePrice;

            //Act
            var calculatedProductPrice = basePriceCalculator.CalculatePrice(product);

            //Assert
            Assert.Equal(baseProductPrice, calculatedProductPrice.Amount);
        }

        [Fact]
        public void CalculatePrice_WhenCalled_ShouldReturnNullLabelValue()
        {
            //Arrange
            var product = TestProducts.Console1;
            var basePriceCalculator = new BasePriceCalculator();

            //Act
            var calculatedProductPrice = basePriceCalculator.CalculatePrice(product);

            //Assert
            Assert.Null(calculatedProductPrice.Label);
        }
    }
}
