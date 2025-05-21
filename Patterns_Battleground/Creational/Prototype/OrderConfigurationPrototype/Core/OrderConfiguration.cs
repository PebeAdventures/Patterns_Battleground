using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components;

namespace Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core
{
    public class OrderConfiguration : IPrototype<OrderConfiguration>
    {
        public string Name { get; }
        public List<HardwareComponent> HardwareComponents { get; }
        public List<Software> SoftwarePackages { get; }

        public OrderConfiguration(string name, List<HardwareComponent> hardwareComponents, List<Software> softwarePackages)
        {
            Name = name;
            HardwareComponents = hardwareComponents;
            SoftwarePackages = softwarePackages;
        }

        public virtual OrderConfiguration Clone()
        {
            return new OrderConfiguration(
                Name,
                HardwareComponents.Select(c => c.Clone()).ToList(),
                SoftwarePackages.Select(sp => sp.Clone()).ToList());
        }
    }
}
