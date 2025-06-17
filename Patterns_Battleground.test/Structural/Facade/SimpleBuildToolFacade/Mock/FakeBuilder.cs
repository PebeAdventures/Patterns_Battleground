using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;

namespace Patterns_Battleground.test.Structural.Facade.SimpleBuildToolFacade.Mock
{
    public class FakeBuilder : IBuilder
    {
        private readonly TestCallTracker _callTracker;
        public bool WasCalled;

        public FakeBuilder(TestCallTracker callTracker) => _callTracker = callTracker;
        

        public void Build()
        {
            WasCalled = true;
            _callTracker.Calls.Add("build");
        }
    }
}
