using Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;

namespace Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Components
{
    public class DotnetBuilder : IBuilder
    {
        public void Build()
        {
            Console.WriteLine("Application has been builded");
        }
    }
}
