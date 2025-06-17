using Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;

namespace Patterns_Battleground.test.Structural.Facade.SimpleBuildToolFacade.Mock;

public class FakePackager : IPackager
{
    private readonly TestCallTracker _callTracker;
    public bool WasCalled;

    public FakePackager(TestCallTracker callTracker) =>_callTracker = callTracker;


    public void Package()
    {
        WasCalled = true;
        _callTracker.Calls.Add("package");
    }

}
