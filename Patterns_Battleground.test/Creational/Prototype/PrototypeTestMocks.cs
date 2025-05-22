using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core;


namespace Patterns_Battleground.test.Creational.Prototype;

/// <summary>
/// Provides mock instances of OrderConfiguration, WorkstationConfiguration, and ServerConfiguration
/// for use in unit tests. Designed to support Prototype pattern examples.
/// </summary>
public static class PrototypeTestMocks
{
    // Base OrderConfiguration mocks
    public static OrderConfiguration BasicOrder => new(
        "Basic Order",
        [new("CPU", "Intel i3"), new("RAM", "8GB")],
        [new("Windows", "10 Home")]
    );

    public static OrderConfiguration AdvancedOrder => new(
        "Advanced Order",
        [new("CPU", "Intel i7"), new("RAM", "32GB"), new("SSD", "1TB")],
        [new("Windows", "11 Pro"), new("Office", "2021")]
    );

    // Additional test clones
    public static OrderConfiguration CloneOfBasicOrder => BasicOrder.CloneAs<OrderConfiguration>();
    public static OrderConfiguration CloneOfAdvancedOrder => AdvancedOrder.CloneAs<OrderConfiguration>();

    // WorkstationConfiguration mocks
    public static WorkstationConfiguration HrStation => new(
        "HR Station",
        [new("CPU", "Intel i5"), new("RAM", "16GB"), new("SSD", "512GB")],
        [new("Windows", "11"), new("Office", "365 Business")],
        "HR"
    );

    public static WorkstationConfiguration DevStation => new(
        "Developer Station",
        [new("CPU", "Ryzen 9"), new("RAM", "64GB"), new("GPU", "RTX 4070")],
        [new("Windows", "11 Pro"), new("Rider", "2023.1")],
        "IT"
    );

    public static WorkstationConfiguration CloneOfHrStation => HrStation.CloneAs<WorkstationConfiguration>();
    public static WorkstationConfiguration CloneOfDevStation => DevStation.CloneAs<WorkstationConfiguration>();

    // ServerConfiguration mocks
    public static ServerConfiguration PhysicalServer => new(
        "Physical Server",
        [new("CPU", "Xeon E5"), new("RAM", "128GB ECC"), new("HDD", "4TB RAID")],
        [new("Linux", "Debian 12"), new("PostgreSQL", "14")],
        isVirtualized: false
    );

    public static ServerConfiguration VirtualServer => new(
        "VM Server",
        [new("vCPU", "4 cores"), new("RAM", "32GB"), new("Storage", "1TB SSD")],
        [new("Ubuntu", "22.04"), new("Docker", "latest")],
        isVirtualized: true
    );

    public static ServerConfiguration CloneOfVirtualServer => VirtualServer.CloneAs<ServerConfiguration>();
    public static ServerConfiguration CloneOfPhysicalServer => PhysicalServer.CloneAs<ServerConfiguration>();
}
