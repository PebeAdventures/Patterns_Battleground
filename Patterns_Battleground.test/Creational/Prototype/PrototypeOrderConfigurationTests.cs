using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core;
using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.MockData;

namespace Patterns_Battleground.test.Creational.Prototype
{
    public class PrototypeOrderConfigurationTests
    {
        [Fact]
        public void Clone_WhenObjectsAreCloned_ReferencesShouldNotBeSame()
        {
            //arrange
             WorkstationConfiguration baseConfiguration = OrderTemplates.HRWorkstation;

            //act
            var clone = baseConfiguration.Clone();

            //assert
            Assert.NotSame(baseConfiguration, clone);
        }
    }
}
