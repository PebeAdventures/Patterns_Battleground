using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;

namespace Patterns_Battleground.test.Structural.Facade.SimpleBuildToolFacade.Mock
{
    public class FakeTester : ITester
    {
        private readonly TestCallTracker _callTracker;

        public FakeTester(TestCallTracker callTracker) => _callTracker = callTracker;


        public bool WasCalled;
        public void RunTests()
        {
            WasCalled = true;
            _callTracker.Calls.Add("test");
        }
    }
}
