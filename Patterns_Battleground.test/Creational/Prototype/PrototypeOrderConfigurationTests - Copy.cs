/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components;
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

        [Fact]
        public void CloneAs_WhenObjectsAreCloned_PropertiesShouldBeSame()
        {
            //arrange
            WorkstationConfiguration baseConfiguration = OrderTemplates.HRWorkstation;

            //act
            var clone = baseConfiguration.CloneAs<WorkstationConfiguration>();

            //assert
            Assert.Equal(baseConfiguration.Name, clone.Name);
            Assert.Equal(baseConfiguration.Department, clone.Department);
            Assert.Equal(baseConfiguration.HardwareComponents.Count, clone.HardwareComponents.Count);
            Assert.Equal(baseConfiguration.SoftwarePackages.Count, clone.SoftwarePackages.Count);
        }

        [Fact]
        public void CloneAs_WhenCloneIsModified_ShouldNotAffectOriginal()
        {
            var baseConfiguration = new OrderConfiguration(
                "TestStation",
                [new("CPU", "i5"), new("RAM", "16GB"), new("SSD", "512GB")],
                [new("Windows", "11"), new("Office", "365")]);

            var clone = baseConfiguration.CloneAs<WorkstationConfiguration>();

            clone.HardwareComponents.Add(new("GPU", "RTX 5090"));

            Assert.Equal(3, baseConfiguration.HardwareComponents.Count);
            Assert.Equal(4, clone.HardwareComponents.Count);
        }


        [Fact]
        public void CloneAs_WhenCalledOnServerConfiguration_ShouldPreserveVirtualization()
        {
            //arrange
            var baseConfiguration = OrderTemplates.BackupServer;

            //act
            var clone = baseConfiguration.CloneAs<ServerConfiguration>();

            //assert
            Assert.Equal(baseConfiguration.IsVirtualized, clone.IsVirtualized);
        }

        [Fact]
        public void CloneAs_WhenCalledOnServerConfiguration_ObjectsShouldNotBeSame()
        {
            //arrange
            var baseConfiguration = OrderTemplates.BackupServer;

            //act
            var clone = baseConfiguration.CloneAs<ServerConfiguration>();

            //assert
            Assert.NotSame(baseConfiguration, clone);
        }

        [Fact]
        public void CloneAs_WhenCalledOnServerConfiguration_PropertiesShouldBeSame()
        {
            //arrange
            var baseConfiguration = OrderTemplates.BackupServer;

            //act
            var clone = baseConfiguration.CloneAs<ServerConfiguration>();

            //assert
            Assert.Equal(baseConfiguration.Name, clone.Name);
            Assert.Equal(baseConfiguration.HardwareComponents.Count, clone.HardwareComponents.Count);
            Assert.Equal(baseConfiguration.SoftwarePackages.Count, clone.SoftwarePackages.Count);
        }

        [Fact]
        public void Clone_WhenCalledOnBaseOrderConfiguration_ShouldCloneSuccessfully()
        {
            var baseConfig = new OrderConfiguration(
                "Generic Order",
                [new("CPU", "i3")],
                [new("Office", "2019")]);

            var clone = baseConfig.Clone();

            Assert.NotSame(baseConfig, clone);
            Assert.Equal(baseConfig.Name, clone.Name);
            Assert.Equal(baseConfig.HardwareComponents.Count, clone.HardwareComponents.Count);
        }

        [Fact]
        public void CloneAs_WhenSoftwareIsModifiedInClone_ShouldNotAffectOriginal()
        {
            var baseConfiguration = OrderTemplates.FinanceWorkstation;
            var clone = baseConfiguration.CloneAs<WorkstationConfiguration>();

            clone.SoftwarePackages[0].Version = "New Version";

            Assert.NotEqual(baseConfiguration.SoftwarePackages[0].Version, clone.SoftwarePackages[0].Version);
        }

    }
}
*/