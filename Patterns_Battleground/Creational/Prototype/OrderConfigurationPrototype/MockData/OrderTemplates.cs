using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components;
using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core;

namespace Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.MockData
{
    public static class OrderTemplates
    {
        public static WorkstationConfiguration HRWorkstation => new(
            name: "HR Workstation",
            hardwareComponents: new List<HardwareComponent>
            {
                 new("CPU", "Intel i5"),
                 new("RAM", "16GB"),
                 new("SSD", "512GB")
            },
            softwarePackages: new List<Software>
            {
                 new("Windows", "11 Pro"),
                 new("Excel", "365 Business")
            },
            department: "HR"
);

        public static WorkstationConfiguration FinanceWorkstation => new(
            name: "Finance Workstation",
            hardwareComponents: new List<HardwareComponent>
            {
                new("CPU", "Intel i7"),
                new("RAM", "32GB"),
                new("SSD", "1TB")
            },
            softwarePackages: new List<Software>
            {
                new("Windows", "11 Pro"),
                new("Excel", "365 Enterprise"),
                new("SAP", "v2.1")
            },
            department: "Finance"
        );

        public static WorkstationConfiguration RichKidWorkstation => new(
            name: "Rich Kid Workstation",
            hardwareComponents: new List<HardwareComponent>
            {
                new("CPU", "Intel i7"),
                new("RAM", "128GB"),
                new("SSD", "4TB"),
                new("GPU", "Nvidia RTX 5090")
            },
            softwarePackages: new List<Software>
            {
                new("Windows", "11 Pro"),
                new("Excel", "365 Enterprise"),
            },
            department: "Finance"
            );

        public static ServerConfiguration BackupServer => new(
            name: "Backup Server",
            [
                new("CPU", "Xeon Gold"),
                new("RAM", "128GB ECC"),
                new("HDD", "4TB RAID")
            ],
            [
                new("Linux", "Debian 12"),
                new("Bacula", "v9")
            ],
            isVirtualized: true
        );
    }
}
