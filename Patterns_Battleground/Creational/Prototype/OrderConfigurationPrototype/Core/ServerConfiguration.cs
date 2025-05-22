using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components;

namespace Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core
{
    public class ServerConfiguration : OrderConfiguration
    {
        public bool IsVirtualized { get; }
        public ServerConfiguration(string name, List<HardwareComponent> hardwareComponents, List<Software> softwarePackages, bool isVirtualized) : base(name, hardwareComponents, softwarePackages)
        {
            IsVirtualized = isVirtualized;
        }

        public override OrderConfiguration Clone()
        {
            return new ServerConfiguration(
                Name,
                HardwareComponents.Select(hc => hc.Clone()).ToList(),
                SoftwarePackages.Select(sp => sp.Clone()).ToList(),
                IsVirtualized);
        }
    }
}
