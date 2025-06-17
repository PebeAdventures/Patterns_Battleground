using Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;

namespace Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Components
{
    public class XUnitTester : ITester
    {
        public void RunTests()
        {
            Console.WriteLine("Tests has been passed");
        }
    }
}
