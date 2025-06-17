using Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Core;

namespace Patterns_Battleground.Structural.Facade.SimpleBuildToolFacade.Components
{
    public class ZipPackager : IPackager
    {
        public void Package()
        {
            Console.WriteLine("Application has been packed to ZIP.");
        }
    }
}
