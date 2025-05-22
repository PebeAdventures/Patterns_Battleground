
using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core;
using static Patterns_Battleground.test.Creational.Prototype.PrototypeTestMocks;

namespace Patterns_Battleground.test.Creational.Prototype;
public class PrototypeOrderConfigurationTests
{

    // ----------- OrderConfiguration Tests -----------

    [Fact]
    public void Clone_WhenCalledOnOrderConfiguration_ShouldReturnDistinctObjectWithSameValues()
    {
        var clone = CloneOfBasicOrder;

        Assert.NotSame(BasicOrder, clone);
        Assert.Equal(BasicOrder.Name, clone.Name);
        Assert.Equal(BasicOrder.HardwareComponents.Count, clone.HardwareComponents.Count);
        Assert.Equal(BasicOrder.SoftwarePackages.Count, clone.SoftwarePackages.Count);
    }

    [Fact]
    public void CloneAs_WhenOrderConfigurationCloneIsModified_ShouldNotAffectOriginal()
    {
        var clone = CloneOfAdvancedOrder;
        clone.HardwareComponents.Add(new("NIC", "10GbE"));

        Assert.NotEqual(AdvancedOrder.HardwareComponents.Count, clone.HardwareComponents.Count);
    }

    // ----------- WorkstationConfiguration Tests -----------

    [Fact]
    public void CloneAs_WhenCalledOnWorkstationConfiguration_ShouldPreserveAllProperties()
    {
        var clone = CloneOfHrStation;

        Assert.Equal(HrStation.Name, clone.Name);
        Assert.Equal(HrStation.Department, clone.Department);
        Assert.Equal(HrStation.HardwareComponents.Count, clone.HardwareComponents.Count);
        Assert.Equal(HrStation.SoftwarePackages.Count, clone.SoftwarePackages.Count);
    }

    [Fact]
    public void CloneAs_WhenModifyingWorkstationClone_ShouldNotAffectOriginal()
    {
        var clone = CloneOfDevStation;
        clone.SoftwarePackages[0] = new("DEV", "Whatever");

        Assert.NotEqual(DevStation.SoftwarePackages[0].Version, clone.SoftwarePackages[0].Version);
    }

    [Fact]
    public void CloneAs_WhenModifyingHardwareListInWorkstationClone_ShouldRemainIndependent()
    {
        var clone = CloneOfHrStation;
        clone.HardwareComponents.Add(new("Monitor", "4K"));

        Assert.NotEqual(HrStation.HardwareComponents.Count, clone.HardwareComponents.Count);
    }

    [Fact]
    public void CloneAs_WhenCloningWorkstationConfiguration_ReferenceShouldNotBeSame()
    {
        var clone = CloneOfDevStation;

        Assert.NotSame(DevStation, clone);
    }

    // ----------- ServerConfiguration Tests -----------

    [Fact]
    public void CloneAs_WhenCalledOnServerConfiguration_ShouldPreserveAllProperties()
    {
        var clone = CloneOfVirtualServer;

        Assert.Equal(VirtualServer.Name, clone.Name);
        Assert.Equal(VirtualServer.IsVirtualized, clone.IsVirtualized);
        Assert.Equal(VirtualServer.HardwareComponents.Count, clone.HardwareComponents.Count);
        Assert.Equal(VirtualServer.SoftwarePackages.Count, clone.SoftwarePackages.Count);
    }

    [Fact]
    public void CloneAs_WhenModifyingServerClone_ShouldNotAffectOriginal()
    {
        var clone = CloneOfPhysicalServer;
        clone.HardwareComponents[0] = new("CHANGED", "Whatever");

        Assert.NotEqual(PhysicalServer.HardwareComponents[0].Name, clone.HardwareComponents[0].Name);
    }

    [Fact]
    public void CloneAs_WhenCloningServerConfiguration_ReferenceShouldNotBeSame()
    {
        var clone = CloneOfPhysicalServer;

        Assert.NotSame(PhysicalServer, clone);
    }

    [Fact]
    public void CloneAs_WhenTypeMismatchOccurs_ShouldThrowException()
    {
        Assert.Throws<InvalidCastException>(() =>
        {
            var _ = HrStation.CloneAs<ServerConfiguration>();
        });
    }
}