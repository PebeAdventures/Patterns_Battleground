using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components;

namespace Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core;

public class WorkstationConfiguration : OrderConfiguration
{
    public string Department { get; }

    public WorkstationConfiguration(
        string name, 
        List<HardwareComponent> hardwareComponents, 
        List<Software> softwarePackages,
        string department
        ) : base(name, hardwareComponents, softwarePackages)
    {
        Department = department;
    }

    public override OrderConfiguration Clone()
    {
        return new WorkstationConfiguration(
            Name,
            HardwareComponents.Select(hc => hc.Clone()).ToList(),
            SoftwarePackages.Select(sp => sp.Clone()).ToList(),
            Department);
    }
}
