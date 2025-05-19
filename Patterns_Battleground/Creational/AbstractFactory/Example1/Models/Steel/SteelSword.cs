using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Steel
{
    public class SteelSword : ISword
    {
        public void Slash()
        {
            Console.WriteLine("Steel sword slices cleanly with a sharp whistle.");
        }
    }
}
