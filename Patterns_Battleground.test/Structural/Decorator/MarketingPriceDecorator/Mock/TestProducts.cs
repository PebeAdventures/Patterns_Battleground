using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Decorator.MarketingPriceDecorator.Core;

namespace Patterns_Battleground.test.Structural.Decorator.MarketingPriceDecorator.Mock
{
    public static class TestProducts
    {
        public static Product Console1 => new("PlayStation 5", 2499.00m);
        public static Product Console2 => new("Xbox 360", 1499.00m);
        public static Product Oven1 => new("Beko oven", 1299.00m);
        public static Product Oven2 => new("Amica oven", 1499.00m);
        public static Product Toy1 => new("Lego OnePiece", 499.00m);
        public static Product Toy2 => new("Watergun", 10.00m);
    }
}
